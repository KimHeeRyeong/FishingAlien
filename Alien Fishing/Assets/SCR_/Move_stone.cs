using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_stone : MonoBehaviour
{
    float ran;
    float turn_x, turn_y, turn_z;
    // Start is called before the first frame update
    void Start()
    {
        ran = Random.Range(1,15);
        turn_x = Random.Range(-3, 3);
        turn_y = Random.Range(-3, 3);
        turn_z = Random.Range(-3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -ran);
        transform.Rotate(transform.rotation.x+ turn_x, transform.rotation.y+ turn_y, transform.rotation.z+ turn_z);
        if (this.GetComponent<Transform>().position.z < 0)
        {
            this.GetComponent<Transform>().position = new Vector3(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y, 100);
            ran = Random.Range(1, 15);
            turn_x = Random.Range(-3, 3);
            turn_y = Random.Range(-3, 3);
            turn_z = Random.Range(-3, 3);
        }
    }
}
