using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    public float speed = 10.0f;
    public float turnSpeed = 400.0f;
    private Vector3 moveDirection = Vector3.zero;
    bool isGround = false;
    void Update()
    {
        if (camTransform.gameObject.activeSelf)
        {
            if (isGround)
            {
                Quaternion target = Quaternion.Euler(0, camTransform.rotation.eulerAngles.y, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10);
                if (Input.GetKey("w"))
                {
                    transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
                }
                else if (Input.GetKey("s"))
                {
                    transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
                }
                else if (Input.GetKey("d"))
                {
                    transform.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                }
                else if (Input.GetKey("a"))
                {
                    transform.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
