using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(LineRenderer))]
public class Catenary : MonoBehaviour
{
    [SerializeField]
    Transform pRod;
    [SerializeField]
    Transform pBait;
    public Transform bait;
    [Range(1,10)]
    public float lineResolution;
    [Range(1f,1000f)]
    public float a;
    LineRenderer lineRenderer;
    public float speed;
    public Transform planet;
    public MeshCollider colider;
    Vector3 saveBaitPos;
    public float castingSpeed = 10;
    public Rigidbody rdBait;
    bool space = false;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetLine();
        saveBaitPos = pBait.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (saveBaitPos != pBait.position)
        {
            SetLine();
            saveBaitPos = pBait.position;
        }

        if (Input.GetMouseButton(0))
        {
           // rdBait.useGravity = false;
           
            int cnt = lineRenderer.positionCount;
            Vector3 moveDir =(pRod.position-pBait.position).normalized;
            //bait.position += moveDir * Time.deltaTime * castingSpeed;
            rdBait.AddForce(moveDir*castingSpeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            // rdBait.useGravity = false;
            int cnt = lineRenderer.positionCount;
            Vector3 moveDir = (pRod.position - pBait.position).normalized;
            //bait.position += moveDir * Time.deltaTime * castingSpeed;
            rdBait.velocity = moveDir * castingSpeed;
        }

        //if (Input.GetMouseButton(1))
        //{
        //    a -= Time.deltaTime*speed;Debug.Log(a);
        //}
    }
    private void SetLine()
    {
        float dis = Vector3.Distance(pRod.position, pBait.position);
        int pCnt = (int)(dis / lineResolution) + 1;

        Vector3[] points = new Vector3[pCnt];
        points[0] = pRod.position;
        points[pCnt - 1] = pBait.position;
        Vector3 dir = (pBait.position - pRod.position).normalized;
        float offset = CatenaryEq(a, -dis / 2);

        for (int i = 1; i < pCnt - 1; ++i)
        {
            Vector3 point = pRod.position + i * lineResolution * dir;
            float x = i * lineResolution - dis / 2;
            point.y = point.y - (offset - CatenaryEq(a, x));

            points[i] = point;
        }
        for (int i = 1; i < pCnt - 2; ++i)
        {
            Ray ray = new Ray();
            ray.origin = points[i];
            ray.direction = (points[i]-points[i+1]);
            RaycastHit hit;
            if(colider.Raycast(ray, out hit,Vector3.Distance(points[i], points[i+1]))){
                float disToRod = Vector3.Distance(pRod.position, planet.position);
                pRod.position = (points[1]-planet.position).normalized*disToRod+planet.position;
                break;
            }

        }
        lineRenderer.positionCount = pCnt;
        lineRenderer.SetPositions(points);
    }
    private float CatenaryEq(float a, float x)
    {
        return a * 0.5f * (Mathf.Exp(x/a)+Mathf.Exp(-(x/a)));
    }
}
