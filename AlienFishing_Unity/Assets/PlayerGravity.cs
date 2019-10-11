using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerGravity : MonoBehaviour
{
    Rigidbody rd;
    public Transform planet;
    Vector3 gravityUP;
    public float grav;
    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
        rd.useGravity = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 gravityUP = (transform.position - planet.position).normalized;
        Physics.gravity = gravityUP * -grav;
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, gravityUP) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50 * Time.deltaTime);

    }
}
