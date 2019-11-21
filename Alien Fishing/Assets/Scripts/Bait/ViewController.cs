using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField] ThirdPersonCamera camBait;
    private void Awake()
    {
        camBait.ViewYFix(true, 75.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            camBait.ViewYFix(false, 75.0f);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            camBait.ViewYFix(true, 75.0f);
        }
    }
}
