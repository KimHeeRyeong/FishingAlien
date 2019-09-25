using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_rote : MonoBehaviour
{
    private float x_ligth;
    // Start is called before the first frame update
    void Start()
    {      
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (x_ligth < 360 && 0 <= x_ligth)
            x_ligth = x_ligth + (Time.deltaTime * 10);
        else
            x_ligth = 0;
        this.GetComponent<Transform>().localEulerAngles = new Vector3(x_ligth, 0, 0);
    }
}
