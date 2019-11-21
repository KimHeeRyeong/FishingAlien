using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRot : MonoBehaviour
{
    [SerializeField] Transform followRot = null;
    // Start is called before the first frame update
    Vector3 dir;
    private void Awake()
    {
        dir = transform.position - followRot.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (followRot == null)
            return;

        Quaternion target = Quaternion.FromToRotation(transform.forward, followRot.forward) *transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10);
        transform.position = followRot.position + transform.rotation * dir;
    }
}
