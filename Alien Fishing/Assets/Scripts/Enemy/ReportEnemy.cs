using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportEnemy : BasicEnemy
{
    [SerializeField] Transform bossReportPos;
    protected override void MoveAround()
    {
        if (bossReportPos == null)
        {
            base.MoveAround();
        }
        else
        {
            agent.SetDestination(bossReportPos.position);
            if (agent.remainingDistance > 1.5f)
                SetRunAnimation();
            else
                SetWalkAnimation();
        }
    }
}
