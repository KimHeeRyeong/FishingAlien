using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShpereNavigation;

public enum EnemyState{
    NONE,
    MOVEAROUND,
    TRACKING,
    ESC
}
public enum EnemyAniState {
    IDLE,
    WALK,
    RUN,
    HIT,
    ATTACK,
    JUMP
}
[RequireComponent (typeof(Rigidbody), typeof(SphereNavAgent), typeof(Animator))]
public class BasicAlien : MonoBehaviour
{
    Rigidbody rd;
    SphereNavAgent agent;
    Animator animator;
    EnemyAniState aniState;
    EnemyState state;
    private void Awake()
    {
        agent = GetComponent<SphereNavAgent>();
        rd = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();
        animator.SetTrigger("Idle");
        aniState = EnemyAniState.IDLE;
        state = EnemyState.NONE;
    }
    private void Start()
    {
    }
    private void Update()
    {
        switch (state)
        {
            case EnemyState.NONE:
                state = EnemyState.MOVEAROUND;
                break;
            case EnemyState.MOVEAROUND:
                MoveAround();
                break;
            case EnemyState.TRACKING:
                Tracking();
                break;
            case EnemyState.ESC:
                Escape();
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        animator.SetTrigger("Hit");
        aniState = EnemyAniState.HIT;
        if (collision.gameObject.CompareTag("Enemy"))
            agent.StopDestination();
    }
    protected virtual void Stop() {
    }
    protected virtual void MoveAround() {
        if (aniState != EnemyAniState.WALK)
        {
            animator.SetTrigger("Walk");
            aniState = EnemyAniState.WALK;
        }
        if (agent.IsGoal())
            agent.SetRandomDestination();
    }
    protected virtual void Tracking()
    {
    }
    protected virtual void Escape()
    {

    }
    //Basic Alien is Move Around planet
        //->make shpere navgation
    //if collision with player -> fishing system start
}
