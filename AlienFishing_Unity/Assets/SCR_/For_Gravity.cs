using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class For_Gravity : MonoBehaviour
{
    public From_Gravity attractor;
    private Vector3 aft_pos = Vector3Int.zero;
    void Awake()
    {
        Rigidbody rd = GetComponent<Rigidbody>();
        rd.constraints = RigidbodyConstraints.FreezeRotation;
        rd.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        aft_pos = attractor.Attract(transform, aft_pos);
    }
}
