using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitCamera : MonoBehaviour
{
    public Transform bait;
    public float fixYAngle = 75f;
    public float distance = 5.0f;

    private const float Y_ANGLE_MIN = -75.0f;
    private const float Y_ANGLE_MAX = -10.0f;

    private float currentX = 0.0f;
    private float currentY = -75;
    BaitController baitController;
    private void Awake()
    {
        baitController = bait.GetComponent<BaitController>();
    }
    private void Update()
    {
        if (Time.timeScale == 0)
            return;
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        if (Time.timeScale == 0)
            return;

        BaitController.BaitState state = baitController.GetState();
        if (state != BaitController.BaitState.MOVE_AROUND)
            currentY = fixYAngle;

        Vector3 dir = new Vector3(0, 0, distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = bait.position + rotation * dir;
        transform.LookAt(bait.position);
    }
}