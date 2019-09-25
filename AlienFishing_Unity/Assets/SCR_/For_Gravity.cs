using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For_Gravity : MonoBehaviour
{
    public From_Gravity attractor;
    public GameObject player;
    private Transform myTransform;
    private Vector3 aft_pos = Vector3Int.zero;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        this.GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        aft_pos = attractor.Attract(myTransform, aft_pos);
    }
}
