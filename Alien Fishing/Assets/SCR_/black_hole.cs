using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class black_hole : MonoBehaviour
{
    public GameObject white_hole;
    public GameObject space_ship_p;
    public Camera camera;
    private void Update()
    {
        if (camera.farClipPlane < 2000)
        {
            camera.farClipPlane = camera.farClipPlane + Time.deltaTime * 100;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        space_ship_p.transform.position = white_hole.transform.position;
        camera_onoff();
    }
    void camera_onoff()
    {
        camera.farClipPlane = 100;
    }
}
