using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle
{
    Vector3 _position, _oldPosition;
    private Transform _boundTo = null;

    public Vector3 position { get => _position; set=>_position=value; }
    public Vector3 velocity { get => _position - _oldPosition; }

    //생성자 : position 및 old position 동일한 값으로 초기화
    public Particle(Vector3 newPosition)
    {
        _oldPosition = _position = newPosition;
    }

    public bool IsBound() {
        return (_boundTo != null);
    }

    //제약
    public void Bind(Transform to)
    {
        _boundTo = to;
        _oldPosition = _position = _boundTo.position;
    }

    public void UnBind()
    {
        _boundTo = null;
    }

    public void UpdatePosition(Vector3 newPos)
    {
        _oldPosition = _position;
        _position = newPos;
    }

    public void UpdateVerlet(Vector3 gravityDisplacement)
    {
        if (IsBound())
        {
            UpdatePosition(_boundTo.position);
        }
        else
        {
            Vector3 newPosition = position + velocity + gravityDisplacement;
            UpdatePosition(newPosition);
        }
    }
}

public class FishingCable : MonoBehaviour
{
    #region Class members

    [SerializeField, HideInInspector] Transform bait;
    // Cable config
    [SerializeField] float segmentLength = 0.5f;
    [SerializeField] float baitMass = 2;
    [SerializeField] float cableLength = 0;
    [SerializeField] float castingSpeed = 10;
    int segmentCnt = 0;
    // Solver config
    [SerializeField] int solverIterations = 1;

    LineRenderer line;
    List<Particle> points;
    MoveBait moveBait;
    float realLength = 0;
    bool baitBind = false;//true=>bait is on ground
    #endregion

    #region Initial setup
    public void SetBait(Transform bait) {
        this.bait = bait;
    }
    void Start()
    {
        line = GetComponent<LineRenderer>();
        moveBait = bait.GetComponent<MoveBait>();
        InitCableParticles();
    }
    
    void InitCableParticles()
    {
        points = new List<Particle>();
        cableLength = cableLength <= 0 ? 0.1f:cableLength;
        realLength = cableLength;
        segmentCnt = Mathf.CeilToInt(cableLength / segmentLength);//올림=>segment 갯수, particle 갯수 = segment+1

        Vector3 cableDirection = (transform.position- bait.position).normalized;
        points.Add(new Particle(bait.position));
        for (int i = 1; i < segmentCnt; i++)
        {
            Vector3 initialPosition = bait.position + (cableDirection * (segmentLength * i));
            points.Add(new Particle(initialPosition));
        }
        points.Add(new Particle(transform.position));
        //제약
        points[segmentCnt].Bind(transform);
    }
    #endregion
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cableLength += Time.deltaTime* castingSpeed;
        }
        else if(Input.GetMouseButton(1))
        {
            cableLength -= Time.deltaTime * castingSpeed;
            if (cableLength < 0)
            {
                cableLength = 0f;
            }
            
        }
    }
    void FixedUpdate()
    {
        EditCableParticle();
        VerletIntegrate();

        //segment 길이 제약
        for (int i = 0; i < solverIterations; i++)
            SolveDistanceConstraint();

        if (baitBind)//미끼가 땅에 있는 경우(줄 끝이 미끼를 따라감)
        {
            if (!points[0].IsBound())
            {
                points[0].Bind(bait);
                points[0].position = bait.position;
            }
        }
        else//미끼가 공중에 위치한 경우(줄 끝의 위치에 따라감)
        {
            if (points[0].IsBound())
            {
                points[0].UnBind();
            }
            bait.position = points[0].position;
        }
        SetTension();
    }
    void LateUpdate()
    {
        RenderCable();
    }

    void RenderCable()
    {
        line.positionCount = segmentCnt + 1;
        for (int i = 0; i < segmentCnt + 1; i++)
            line.SetPosition(i, points[i].position);
    }
    void EditCableParticle()
    {
        if (segmentLength * segmentCnt < cableLength)
        {
            Vector3 direction = (transform.position - points[segmentCnt - 1].position).normalized;
            points[segmentCnt].UnBind();
            points[segmentCnt].position = points[segmentCnt - 1].position + direction * segmentLength;
            points.Add(new Particle(transform.position));
            segmentCnt++;
            points[segmentCnt].Bind(transform);
        }
        //particle 갯수 줄여야하는 경우
        else if (segmentLength * (segmentCnt-1) > cableLength)
        {
            if (segmentCnt == 1)
                return;
            Vector3 direction = (transform.position - points[segmentCnt - 1].position).normalized;
            points[segmentCnt].UnBind();
            points.RemoveAt(segmentCnt);
            segmentCnt--;
            points[segmentCnt].position = transform.position;
            points[segmentCnt].Bind(transform);
        }
    }

    void VerletIntegrate()
    {
        Vector3 gravityDisplacement = Time.fixedDeltaTime * Time.fixedDeltaTime * Physics.gravity*10;
        for(int i = 0; i < segmentCnt; i++)
        {
            points[i].UpdateVerlet(gravityDisplacement);
        }
        points[segmentCnt].UpdateVerlet(gravityDisplacement / baitMass);
    }
    
    void SolveDistanceConstraint()
    {
        for (int i = 0; i < segmentCnt; i++)
        {
            Particle particleA = points[i];
            Particle particleB = points[i + 1];

            // Find current vector between particles
            Vector3 delta = particleB.position - particleA.position;
            float currentDistance = delta.magnitude;
            float errorFactor;
            if (i == segmentCnt)
            {
                float segLength = cableLength - ((segmentCnt - 1) * segmentLength);
                if (segLength < 0) segLength = 0;
                errorFactor = (currentDistance - segmentLength) / currentDistance;
            }
            else
                errorFactor = (currentDistance - segmentLength) / currentDistance;

            // 두 particle 모두 제약이 없을때
            if (!particleA.IsBound() && !particleB.IsBound())
            {
                particleA.position += errorFactor * 0.5f * delta;
                particleB.position -= errorFactor * 0.5f * delta;
            }
            //둘 중 1개만 제약이 있는 경우
            else if (!particleA.IsBound())
            {
                particleA.position += errorFactor * delta;
            }
            else if (!particleB.IsBound())
            {
                particleB.position -= errorFactor * delta;
            }
        }
    }
    void SetTension()
    {
        realLength = 0;
        for (int i = 0; i < segmentCnt; i++)
        {
            realLength += Vector3.Distance(points[i].position, points[i + 1].position);
        }
        float distance = Vector3.Distance(points[segmentCnt].position, points[0].position); //줄의 시작점과 끝점 거리
        float tension = (realLength/ distance);
        if (tension>1) tension = 1;
        tension = 1 - tension;
        GameSingleton.Instance.tension = tension;
    }

    public void SetBaitBind(bool bind) {
        baitBind = bind;
    }
    //private void OnDrawGizmos()
    //{
    //    int cnt = points.Count;
    //    for(int i = 0; i < cnt; i++)
    //    {
    //        Gizmos.DrawSphere(points[i].position, 0.5f);
    //    }
    //}
}
