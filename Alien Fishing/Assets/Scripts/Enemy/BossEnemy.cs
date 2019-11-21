using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : BasicEnemy
{
    protected override void MeetBait()
    {
        if(state!=EnemyState.FIGHT)
        state = EnemyState.TRACKING;
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        sound_single.Instance.PlayM_shout();
    }
}
