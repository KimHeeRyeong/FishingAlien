using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(LineRenderer), typeof(SpringJoint))]
public class Catenary : MonoBehaviour
{
    [SerializeField]
    Transform pBait;
    public Transform bait;
    [Range(1,10)]
    public float lineResolution;
    [Range(1f,1000f)]
    public float a;
    LineRenderer lineRenderer;
    Vector3 saveBaitPos;
    public float castingSpeed = 10;
    SpringJoint springJoint;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        springJoint = GetComponent<SpringJoint>();
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
            Vector3 moveDir =(transform.position-pBait.position).normalized;
            bait.position += moveDir * Time.deltaTime * castingSpeed;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            // rdBait.useGravity = false;
            int cnt = lineRenderer.positionCount;
            Vector3 moveDir = (transform.position - pBait.position).normalized;
            //bait.position += moveDir * Time.deltaTime * castingSpeed;
        }
    }
    private void SetLine()
    {
        float dis = Vector3.Distance(transform.position, pBait.position);
        int pCnt = (int)(dis / lineResolution) + 1;

        Vector3[] points = new Vector3[pCnt];
        points[0] = transform.position;
        points[pCnt - 1] = pBait.position;
        Vector3 dir = (pBait.position - transform.position).normalized;
        float offset = CatenaryEq(a, -dis / 2);

        for (int i = 1; i < pCnt - 1; ++i)
        {
            Vector3 point = transform.position + i * lineResolution * dir;
            float x = i * lineResolution - dis / 2;
            point.y = point.y - (offset - CatenaryEq(a, x));

            points[i] = point;
        }
        lineRenderer.positionCount = pCnt;
        lineRenderer.SetPositions(points);
    }
    private float CatenaryEq(float a, float x)
    {
        return a * 0.5f * (Mathf.Exp(x/a)+Mathf.Exp(-(x/a)));
    }
}
