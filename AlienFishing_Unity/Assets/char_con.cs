using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_con : MonoBehaviour
{
    public CharacterController CC = null;

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        if (CC.isGrounded == true)
        {
            Debug.Log("groud");


            Vector3 vv = (Vector3.zero - this.transform.position).normalized;
            Debug.Log(vv);
            CC.Move(vv);
        }
    }
}
