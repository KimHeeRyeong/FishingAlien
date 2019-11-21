using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeEnemy : BasicEnemy
{
    protected override void MeetBait()
    {
        state = EnemyState.ESCAPE;
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        sound_single.Instance.PlayM_r();
    }
}
