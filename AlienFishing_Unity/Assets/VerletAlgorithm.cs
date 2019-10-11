using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Segment
{
    public Vector3 t;//posNow
    public Vector3 t_dt;//posOld(t-dt)
    public Segment(Vector3 pos){
        t = pos;
        t_dt = pos;
    } 
}
[RequireComponent (typeof(LineRenderer))]
public class VerletAlgorithm : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    [SerializeField] Transform gravCenter;
    [Range(0.1f,5f)]
    [SerializeField] float segmentLength = 1f;

    List<Segment> segs;
    LineRenderer line;
    float lineLength = 0;
    float m = 0.1f;
    void Awake()
    {
        segs = new List<Segment>();
        line = GetComponent<LineRenderer>();
        InitSegment();
        SetLinePosition();
    }
    void InitSegment() {
        lineLength = Vector3.Distance(startPos.position, endPos.position);
        int segCnt = Mathf.CeilToInt(lineLength / segmentLength);

        segs.Add(new Segment(startPos.position));
        for (int i = 1; i < segCnt-1; i++)
        {
            Vector3 pos = startPos.position;
            Vector3 dir = (endPos.position - startPos.position).normalized;
            pos += i *dir * segmentLength;
            segs.Add(new Segment(pos));
        }
        segs.Add(new Segment(endPos.position));
    }

    void Start()
    {
       // StartCoroutine(smulTest());
    }
    
    void FixedUpdate()
    {
        Simulate();
        SetLinePosition();
    }
    void Simulate()
    {
        int cnt = segs.Count;
        segs[0].t = startPos.position;
        segs[cnt - 1].t = endPos.position;
        for (int i = 1; i < cnt - 1; i++)
        {
            Vector3 g = (gravCenter.position - segs[i].t).normalized *9.8f * Time.fixedDeltaTime * Time.fixedDeltaTime;
            Vector3 posNext = 2*segs[i].t - segs[i].t_dt +g;
            segs[i].t_dt = segs[i].t;
            segs[i].t = posNext;
        }
        Consrtaint();
    }
    void Consrtaint()
    {
        int cnt = segs.Count;
        float segLength = lineLength/(float)cnt;
        for (int i = 0; i < cnt-1; i++)
        {
            Vector3 dir = segs[i + 1].t- segs[i].t;
            float error = dir.magnitude - segLength;
            dir.Normalize();
            Vector3 changeAmount = dir * error;
            if (i == 0)
            {
                segs[i + 1].t -= changeAmount;
                
            }else if (i == cnt - 2)
            {
                segs[i].t += changeAmount;
            }
            else
            {
                segs[i].t += changeAmount*0.5f;
                segs[i + 1].t -= changeAmount*0.5f;
            }
        }
        
    }
    void SetLinePosition() {
        int cnt = segs.Count;
        line.positionCount = cnt;
        for(int i = 0; i < cnt; i++)
        {
            line.SetPosition(i, segs[i].t);
        }
    }

}