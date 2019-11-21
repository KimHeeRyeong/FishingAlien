using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveBait : MonoBehaviour
{
    private Animator anim;
    public Transform camTransform;
    public float walkSpeed = 1.0f;
    public float turnSpeed = 400.0f;
    private Vector3 moveDirection = Vector3.zero;
    bool isGrounded = false;

    void Awake()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }
    void Update() {


    }
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
            Walk(Input.GetAxis("Vertical"), 0);
        else if (Input.GetKey("s"))
            Walk(-Input.GetAxis("Vertical"), 180);    
        else if (Input.GetKey("d"))
            Walk(Input.GetAxis("Horizontal"), 90);
        else if (Input.GetKey("a"))
            Walk(-Input.GetAxis("Horizontal"), -90);
        else //idle
            Idle();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("enter");
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("exit");
            isGrounded = false;
        }
    }

    void Walk(float axis, float rotate) {
        Quaternion target = Quaternion.Euler(0, camTransform.rotation.eulerAngles.y +rotate, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10);
        if (isGrounded)
        {
            transform.position += transform.forward * axis * walkSpeed * Time.deltaTime;
            if (!anim.GetBool("Walk"))
                anim.SetBool("Walk", true);
        }
        else
            Idle();
    }
    void Idle() {
        if (anim.GetBool("Walk"))
            anim.SetBool("Walk", false);
    }
}
