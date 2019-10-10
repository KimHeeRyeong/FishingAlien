using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class player_move_scr : MonoBehaviour
{ 
    public float speed = 4;
    public float jump = 5.0f;

    public GameObject Barrier;
    public GameObject get_ene;

    private Rigidbody rb;

    float x,z;

    int rock_check = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //이동
        x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, z);

        if (x != 0 || z != 0)
        { 
            GameObject.Find("Move_player_sound").GetComponent<AudioSource>().loop = true;
            if(GameObject.Find("Move_player_sound").GetComponent<AudioSource>().isPlaying==false)
            GameObject.Find("Move_player_sound").GetComponent<AudioSource>().Play();
        }
        else
        { GameObject.Find("Move_player_sound").GetComponent<AudioSource>().loop = false; }
    }
    private void OnCollisionStay(Collision collision)
    {
        rock_check--;
        if (rock_check == 0)
        {
            this.GetComponent<CapsuleCollider>().material = null;
        }
        if (Input.GetKeyDown(KeyCode.Space) && collision.gameObject.tag == "Rock")
        {
            rb.velocity = transform.up * 30;           
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy"&&collision.transform.GetComponent<Enemy_move_scr>().ene_Hp <= 0)
        {
            get_ene = collision.gameObject;            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Enemy" && collision.transform.GetComponent<Enemy_move_scr>().ene_Hp <= 0)
        {
            get_ene = null;
        }
    }

}
