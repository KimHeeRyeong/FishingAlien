using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ShpereNavigation
{
    public class SphereNavAgent :MonoBehaviour
    {
        [SerializeField]
        Transform planet;
        public float speed=3.0f;

        AStarFindPath findPath;
        bool _goal;
        uint _goalID;
        int _vertCnt;
        float distanceLimit = 0.1f;
        List<Vector3> path;
        Vector3 gravityUP;
        Vector3 direction;
        Vector3 movePath0;
        private void Awake()
        { 
            _goal = true;
            path = null;
            findPath = planet.GetComponent<AStarFindPath>();
            _vertCnt = findPath.GetVertCnt();
            _goalID = (uint)_vertCnt;
        }
        private void FixedUpdate()
        {
            if (!_goal)
            {
                transform.position += direction * speed * Time.deltaTime;
                
                //rotation
                gravityUP = (transform.position - planet.position).normalized;

                if (transform.forward != direction)
                {
                    Quaternion forwardRotation = Quaternion.FromToRotation(transform.forward, direction) * transform.rotation;
                    transform.rotation = Quaternion.Slerp(transform.rotation, forwardRotation, 10 * Time.deltaTime);
                }
                if (transform.up != gravityUP)
                {
                    Quaternion gravityRotation = Quaternion.FromToRotation(transform.up, gravityUP) * transform.rotation;
                    transform.rotation = Quaternion.Slerp(transform.rotation, gravityRotation, 50 * Time.deltaTime);
                }

                if (Vector3.Distance(transform.position, movePath0) < distanceLimit)
                {
                    path.RemoveAt(0);
                    if (path.Count == 0)
                    {
                        _goal = true;
                        return;
                    }
                    movePath0 = path[0];
                    direction = movePath0 - transform.position;
                    direction.Normalize();
                }
            }
        }
        public void SetDestination(Vector3 moveTo)
        {
            if (moveTo == null)
            {
                Debug.Log("move to null");
                return;
            }
            uint start_id = findPath.GetPositionId(transform.position);
            uint goal_id = findPath.GetPositionId(moveTo);
            if (goal_id == _goalID)
                return;
            _goalID = goal_id;
            path = findPath.FindPathOrNull(start_id,goal_id);
            if (path != null)
            {
                _goal = false;
                movePath0 = path[0];
                direction = movePath0 - transform.position;
                direction.Normalize();
            }
            
        }
        public void SetRandomDestination()
        {
            uint start_id = findPath.GetPositionId(transform.position);
            uint goal_id = (uint)Random.Range(0, _vertCnt);
            path = findPath.FindPathOrNull(start_id, goal_id);
            if (path != null)
            {
                _goal = false;
                movePath0 = path[0];
                direction = movePath0 - transform.position;
                direction.Normalize();
            }
        }
        public void StopDestination() {
            path = null;
            _goal = true;
            _goalID = (uint)_vertCnt;
        }
        public bool IsGoal()
        {
            return _goal;
        }
    }
}
