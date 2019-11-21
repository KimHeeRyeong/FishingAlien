using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingEnemy : BasicEnemy
{
    protected override void MeetBait()
    {
        state = EnemyState.TRACKING;
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        sound_single.Instance.PlayM_q();
    }
}
