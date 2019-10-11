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
    [SerializeField] Transform startPos;//bait position
    [SerializeField] Transform endPos;//rod position
    [SerializeField] Transform gravCenter;
    [Range(0.1f,5f)]
    [SerializeField] float segLength_max = 1f;
    [SerializeField] float lineLength_max = 15f;
    [SerializeField] float castingSpeed = 3.0f;
    List<Segment> segs;
    LineRenderer line;
    float lineLength = 0;
    float m = 0.1f;
    float segLength = 0;
    float Lmin = 0;
    #region Initialize 
    void Awake()
    {
        segs = new List<Segment>();
        line = GetComponent<LineRenderer>();
        InitSegment();
        SetLinePosition();
    }
    void InitSegment()
    {
        lineLength = Vector3.Distance(startPos.position, endPos.position);
        Lmin = lineLength;
        int segCnt = Mathf.CeilToInt(lineLength / segLength_max);
        if (segCnt != 0)
        {
            segLength = lineLength / segCnt;
        }
        segs.Add(new Segment(startPos.position));
        for (int i = 1; i < segCnt; i++)
        {
            Vector3 pos = startPos.position;
            Vector3 dir = (endPos.position - startPos.position).normalized;
            pos += i * dir * segLength;
            segs.Add(new Segment(pos));
        }
        segs.Add(new Segment(endPos.position));
        //segs always more than 2
    }
    #endregion

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            lineLength -= Time.deltaTime * castingSpeed;
            if (lineLength < Lmin)
            {
                Vector3 dir = (endPos.position - startPos.position).normalized;
                startPos.position += (segs[1].t- segs[0].t).normalized*Time.deltaTime*castingSpeed;
            }
        }
        Simulate();
        SetLinePosition();
        CheckSegment();
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
        for(int i = 0;i<2;i++)
        LengthConsrtaint();
    }
    void CheckSegment() {
        Lmin = Vector3.Distance(startPos.position, endPos.position);
        if (Lmin>=lineLength_max)//flow bait
        {
            lineLength = lineLength_max;
        }else if(Lmin>lineLength)
        {
            lineLength = Lmin;
        }
    }
    void LengthConsrtaint()
    {
        int cnt = segs.Count;
        Vector3 dir = Vector3.zero;
        float error = 0;
        Vector3 change = Vector3.zero;
        for (int i = 0; i < cnt - 1; i++)
        {
            dir = segs[i + 1].t - segs[i].t;
            error = dir.magnitude - segLength;
            dir.Normalize();
            change = dir * error;
            if (i == 0)
            {
                segs[i + 1].t -= change;

            }
            if (i == cnt - 2)
            {
                segs[i].t += change;
            }
            else
            {
                segs[i].t += change * 0.5f;
                segs[i + 1].t -= change * 0.5f;
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