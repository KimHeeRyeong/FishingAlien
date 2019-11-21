//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    NONE,
    MOVEAROUND,
    TRACKING,
    ESCAPE,
    FIGHT
}
public enum EnemyAniState
{
    IDLE,
    WALK,
    RUN,
    HIT,
    ATTACK,
    JUMP
}
public enum EnemyRot
{
    FORWARD,
    RIGHT,
    LEFT
}
[RequireComponent(typeof(NavMeshAgent))]
public class BasicEnemy : MonoBehaviour
{
    [SerializeField] Transform movingPoints;
    [SerializeField] float remainingDistanceLimit = 1.0f;
    [SerializeField] string enemyUIDCODE = "02004";
    [SerializeField] Transform chunk;

    protected Vector3[] points = null;//movingPoints의 자식 오브젝트 position(=>고정점이므로 vector3로 받아옴)
    protected int pointCount = 0;//points 총 갯수
    protected int movingNum = -1;//현재 이동할 points의 번호, -1인 경우 이동번호 지정안한 상태
    Animator animator = null;
    EnemyAniState aniState;

    protected EnemyState state;
    protected NavMeshAgent agent = null;
    protected Transform playerPos = null;
    float walkSpeed;
    float runSpeed;
    Vector3 chunkPos;

    Vector3 dir;
    Vector3 dirR;
    Vector3 dirL;
    protected EnemyRot stateRot = new EnemyRot();

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        walkSpeed = agent.speed;
        runSpeed = walkSpeed * 2;

        animator = GetComponent<Animator>();
        animator.SetTrigger("Idle");
        aniState = EnemyAniState.IDLE;
        state = EnemyState.NONE;
        stateRot = EnemyRot.FORWARD;
        initMovingPoints();
        chunkPos = chunk.position;
    }
    public void EnemyBasicSetting(Transform movingPoints, Transform chunk)
    {
        this.movingPoints = movingPoints;
        this.chunk = chunk;
    }
    void initMovingPoints()
    {
        if (movingPoints == null)
        {
            pointCount = 0;
            return;
        }
        pointCount = movingPoints.childCount;
        if (pointCount != 0)
        {
            movingNum = -1;
            agent.enabled = false;
            state = EnemyState.NONE;
            points = new Vector3[pointCount];
            for (int i = 0; i < pointCount; i++)
                points[i] = movingPoints.GetChild(i).position;
            int randPos = Random.Range(0, pointCount);
            agent.updatePosition = true;
            transform.position = points[randPos];
            agent.enabled = true;
        }
    }
    private void LateUpdate()
    {
        if (chunkPos != chunk.position)
        {
            chunkPos = chunk.position;
            initMovingPoints();
        }
    }
    void FixedUpdate()
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
                Trancking();
                break;
            case EnemyState.ESCAPE:
                Escape();
                break;
            case EnemyState.FIGHT:
                Fight();
                break;
        }
    }
    #region stateMethod
    protected virtual void MoveAround()
    {
        //이동할 포인트가 없는경우 제자리에
        if (pointCount == 0)
        {
            SetIdleAnimation();
            return;
        }

        SetWalkAnimation();
        if (movingNum == -1)
        {
            int rand = Random.Range(0, pointCount * 10);
            movingNum = Mathf.FloorToInt(rand * 0.1f);
            agent.SetDestination(points[movingNum]);
        }
        else
        {
            if (agent.remainingDistance < remainingDistanceLimit)
                movingNum = -1;
        }
        stateRot = EnemyRot.FORWARD;
    }
    protected virtual void Trancking()
    {
        if (playerPos == null)
            return;

        SetRunAnimation();
        agent.SetDestination(playerPos.position);

    }
    protected virtual void Escape()
    {
        if (playerPos == null)
            return;

        SetRunAnimation();
        dir = (transform.position - playerPos.position).normalized;

        switch (stateRot)
        {
            case EnemyRot.FORWARD:
                {
                    dirR = Vector3.Cross(dir, transform.up).normalized;
                    dirL = -dirR;
                    agent.SetDestination(transform.position + dir);
                    if (!agent.hasPath)
                    {
                        stateRot = EnemyRot.RIGHT;
                        agent.SetDestination(transform.position + dirR);
                        if (!agent.hasPath)
                        {
                            stateRot = EnemyRot.LEFT;
                            agent.SetDestination(transform.position + dirL);
                        }
                    }
                }
                break;
            case EnemyRot.RIGHT:
                {
                    agent.SetDestination(transform.position + dirR);
                    float angle = Vector3.SignedAngle(dir, dirR, Vector3.up);
                    if (!agent.hasPath || angle > 120 || angle < -120)
                    {
                        stateRot = EnemyRot.FORWARD;
                        agent.SetDestination(transform.position + dir);
                        dirR = Vector3.Cross(dir, transform.up).normalized;
                        dirL = -dirR;
                        if (!agent.hasPath)
                        {
                            stateRot = EnemyRot.LEFT;
                            agent.SetDestination(transform.position + dirL);
                        }
                    }
                }
                break;
            case EnemyRot.LEFT:
                {
                    agent.SetDestination(transform.position + dirL);
                    float angle = Vector3.SignedAngle(dir, dirL, Vector3.up);
                    if (!agent.hasPath || angle > 120 || angle < -120)
                    {
                        stateRot = EnemyRot.FORWARD;
                        agent.SetDestination(transform.position + dir);
                        dirR = Vector3.Cross(dir, transform.up).normalized;
                        dirL = -dirR;
                        if (!agent.hasPath)
                        {
                            stateRot = EnemyRot.RIGHT;
                            agent.SetDestination(transform.position + dirR);
                        }
                    }
                }
                break;
        }
    }
    protected virtual void Fight()
    {
        SetRunAnimation();
        if (movingNum == -1)
        {
            int rand = Random.Range(0, pointCount * 10);
            movingNum = Mathf.FloorToInt(rand * 0.1f);
            agent.SetDestination(points[movingNum]);
        }
        else
        {
            if (agent.remainingDistance < remainingDistanceLimit)
                movingNum = -1;
        }
    }
    public void SetFight()
    {
        state = EnemyState.FIGHT;
    }
    #endregion
    #region setAnimation
    protected void SetRunAnimation()
    {
        if (aniState != EnemyAniState.RUN)
        {
            animator.SetTrigger("Run");
            aniState = EnemyAniState.RUN;
            agent.speed = runSpeed;
        }
    }
    protected void SetWalkAnimation()
    {
        if (aniState != EnemyAniState.WALK)
        {
            animator.SetTrigger("Walk");
            aniState = EnemyAniState.WALK;
            agent.speed = walkSpeed;
        }
    }
    protected void SetIdleAnimation()
    {
        if (aniState != EnemyAniState.IDLE)
        {
            animator.SetTrigger("Idle");
            aniState = EnemyAniState.IDLE;
            agent.isStopped = true;
        }
    }
    #endregion 
    #region trigger
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bait"))
        {
            playerPos = other.transform;
            MeetBait();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Bait"))
        {
            MeetBait();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bait"))
        {
            state = EnemyState.NONE;
        }
    }
    protected virtual void MeetBait()
    {
    }
    #endregion
    // Test
    private void OnDrawGizmos()
    {

        if (agent != null && agent.hasPath)
        {
            Vector3[] corners = agent.path.corners;
            int cnt = corners.Length;
            if (cnt == 0)
                return;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, corners[0]);
            for (int i = 0; i < cnt - 1; i++)
            {
                Gizmos.DrawLine(corners[i], corners[i + 1]);
            }
        }
    }
    public string GetEnemyID()
    {
        return enemyUIDCODE;
    }
}