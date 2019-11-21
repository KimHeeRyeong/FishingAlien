using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star_fall : MonoBehaviour
{
    Rigidbody rb;
    Vector3 start;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        start = this.transform.position;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(-5, -5, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -7)
        {
            this.transform.position = new Vector3(-10, -10, -10);
            this.transform.position = start;
        }
    }
}
