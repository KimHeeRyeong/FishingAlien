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
            int cnt = lineRenderer.positionCount;
            Ray ray = new Ray();
            ray.origin = lineRenderer.GetPosition(cnt - 1);
            ray.direction = (planet.position-lineRenderer.GetPosition(cnt - 1)).normalized;
            RaycastHit hit;
            Vector3 moveDir = Vector3.zero;
            if (colider.Raycast(ray, out hit, 100))
            {
                moveDir= hit.point;
            }
            ray.origin = lineRenderer.GetPosition(cnt - 2);
            ray.direction = (planet.position - lineRenderer.GetPosition(cnt - 2)).normalized;
            if (colider.Raycast(ray, out hit, 100))
            {
                moveDir =hit.point-moveDir;
            }
            bait.position += moveDir * Time.deltaTime * castingSpeed;
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
        for (int i = 1; i < pCnt - 1; ++i)
        {
            Vector3 dirToPlanet = (planet.position - points[i]).normalized;
            float scale = 200;
            Ray ray = new Ray();
            ray.origin = points[i]- scale * dirToPlanet;
            ray.direction = dirToPlanet;
            RaycastHit hit;
            if(colider.Raycast(ray, out hit,scale)){
                points[i] = hit.point-dirToPlanet*0.2f;
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
