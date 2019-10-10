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
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, z);
    }
    private void OnCollisionStay(Collision collision)
    {
        rock_check--;
        if (rock_check == 0)
        {
            this.GetComponent<CapsuleCollider>().material = null;
        }
        //if (Input.GetKeyDown(KeyCode.Space) && collision.gameObject.tag == "Enemy")
        //{
        //    transform.position = ship.transform.position;
        //}
        if (Input.GetKeyDown(KeyCode.Space) && collision.gameObject.tag == "Rock")
        {
            //rb.AddForce(transform.up * 30000 * jump * Time.deltaTime);
            rb.velocity = transform.up * 30;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.transform.tag == "Enemy"&&collision.transform.GetComponent<Enemy_move_scr>().ene_Hp <= 0)
        //{
        //    get_ene = collision.gameObject;            
        //}
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.transform.tag == "Enemy" && collision.transform.GetComponent<Enemy_move_scr>().ene_Hp <= 0)
    //    {
    //        get_ene = null;
    //    }
    //    if (collision.transform.tag == "Rock")
    //    {
    //        this.GetComponent<Rigidbody>().AddForce(-Vector3.up);
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if (Barrier.GetComponent<MeshRenderer>().material.color.a == 0.5f)
    //    {
    //        if (other.transform.tag == "Enemy" && other.GetComponent<Enemy_move_scr>().ene_Hp >= 1)
    //        {
    //            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 10);
    //        }
    //    }
    //}
}
