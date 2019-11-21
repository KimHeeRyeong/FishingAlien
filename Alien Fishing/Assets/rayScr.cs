using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayScr : MonoBehaviour
{
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward*30, Color.blue);
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 30.0f)) {            
            Debug.Log(hit.transform.name);
        }


    }
}
