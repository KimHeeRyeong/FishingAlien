using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShinyCube : MonoBehaviour
{
    float speed = 3;
    float move = 2f;
    float firstPos;
    bool up = true;
    private void Awake()
    {
        firstPos = transform.position.y;
    }
    private void Update()
    {
        if (up)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            if (transform.position.y > firstPos + move)
                up = false;
        }
        else
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            if (transform.position.y < firstPos - move)
                up = true;
        }
    }

}
