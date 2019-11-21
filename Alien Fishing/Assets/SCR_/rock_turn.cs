using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_turn : MonoBehaviour
{
    float ran_z=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ran_z = GetComponentInParent<planet_move>().ran_y;
        transform.Rotate(-ran_z * Time.deltaTime, 0, 0);
    }
}
