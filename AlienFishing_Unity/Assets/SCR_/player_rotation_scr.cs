using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_rotation_scr : MonoBehaviour
{
    public Animator ani;
    
    void Start()
    {        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            ani.SetInteger("AnimationPar", 1);
            transform.localEulerAngles = new Vector3(0, 315, 0);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            ani.SetInteger("AnimationPar", 1);
            transform.localEulerAngles = new Vector3(0, 45, 0);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            ani.SetInteger("AnimationPar", 1);
            transform.localEulerAngles = new Vector3(0, 225, 0);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            ani.SetInteger("AnimationPar", 1);
            transform.localEulerAngles = new Vector3(0, 135, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ani.SetInteger("AnimationPar", 1);
            transform.localEulerAngles = new Vector3(0, 270, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ani.SetInteger("AnimationPar", 1);
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            ani.SetInteger("AnimationPar", 1);
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ani.SetInteger("AnimationPar", 1);
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            ani.SetInteger("AnimationPar", 0);
        }
    }
}
