using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 20.0f;
    private const float Y_ANGLE_MAX = 75.0f;

    public Transform lookAt;
    public float distance = 5.0f;

    private float currentX = 0.0f;
    private float currentY = 75.0f;
    bool fixViewY = true;

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        if (!fixViewY)
        {
            currentY += Input.GetAxis("Mouse Y");
            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * dir;
        transform.LookAt(lookAt.position);
    }
    public void ViewYFix(bool fix, float Y) {
        fixViewY = fix;
        currentY = Y;
    }
}
