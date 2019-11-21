using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet_move : MonoBehaviour
{
    public float ran_x, ran_y, ran_z;
    public float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        ran_x = Random.Range(-0.5f, 0.5f) * speed;
        ran_y = Random.Range(-0.5f, 0.5f) * speed;
        ran_z = Random.Range(-0.5f, 0.5f) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(ran_x * Time.deltaTime, ran_y * Time.deltaTime, ran_z * Time.deltaTime);
    }
}
