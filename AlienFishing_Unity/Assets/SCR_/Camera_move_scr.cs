using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move_scr : MonoBehaviour
{

    public GameObject target;
    public float xspeed = 3.5f;
    public GameObject Barrier;

    float sensitivity = 17f;
    float minfov = 10;
    float maxfov = 100;
    bool zoomin = false;
    bool zoomout = false;
    float zoom = 55;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Mouse X") * xspeed);
            transform.RotateAround(target.transform.position, transform.right, -Input.GetAxis("Mouse Y") * xspeed);
        }
        if (Barrier.GetComponent<MeshRenderer>().material.color.a == 0.4f)
        {
            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
            fov = Mathf.Clamp(fov, minfov, maxfov);
            Camera.main.fieldOfView = zoom;
            if (zoom > 30.0f)
            {
                zoomin = true;
            }
        }
        else
        {
            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
            fov = Mathf.Clamp(fov, minfov, maxfov);
            Camera.main.fieldOfView = zoom;
            if (zoom <55)
            {
                zoomout = true;
            }
        }

        if (zoomin == true)
        {
            zoom -= Time.deltaTime*55;
            if (zoom < 30)
            { zoomin = false; }
        }
        if(zoomout == true)
        {
            zoom += Time.deltaTime*25;
            if (zoom > 55)
            { zoomout = false; }
        }
    }
}
