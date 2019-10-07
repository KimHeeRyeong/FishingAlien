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
    Transform playerPos;
    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
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
    private void OnTriggerEnter(Collider other)
    {
        agent.StopDestination();
        state = EnemyState.TRACKING;
    }
    private void OnTriggerExit(Collider other)
    {
        agent.StopDestination();
        state = EnemyState.NONE;
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
        if (aniState != EnemyAniState.RUN)
        {
            animator.SetTrigger("Run");
            aniState = EnemyAniState.RUN;
        }
        agent.SetDestination(playerPos.position);
    }
    protected virtual void Escape()
    {
        //if (aniState != EnemyAniState.WALK)
        //{
        //    animator.SetTrigger("Walk");
        //    aniState = EnemyAniState.WALK;
        //}
        //if (agent.IsGoal())
        //    agent.SetDestination(playerPos.position);
    }

}
