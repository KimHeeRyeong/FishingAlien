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
    [Range(1,10)]
    public float lineResolution;
    [Range(3f,10f)]
    public float a;
    LineRenderer lineRenderer;
    public float speed;
    
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetLine();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetLine();
        if (Input.GetMouseButton(0))
        {
            a += Time.deltaTime*speed;
        }
        if (Input.GetMouseButton(1))
        {
            a -= Time.deltaTime*speed;
        }
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
            Debug.Log(CatenaryEq(a, x));
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
