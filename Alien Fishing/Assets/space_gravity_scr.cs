using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class space_gravity_scr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = -transform.up*10;
    }
}
