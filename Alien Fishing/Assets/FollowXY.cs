using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowXY : MonoBehaviour
{
    [SerializeField] Transform follow;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;   
    }
    public void SetFollw(Transform follow) {
        this.follow = follow;
    }
    // Update is called once per frame
    void Update()
    {
        if (follow == null)
            return;
        transform.position = new Vector3(follow.position.x, y, follow.position.z);
    }
}
