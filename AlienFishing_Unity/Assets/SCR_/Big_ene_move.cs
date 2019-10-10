﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_ene_move : MonoBehaviour
{
    public GameObject target_player;
    public GameObject what_is;
    public GameObject Barrier;
    public GameObject heart;
    public From_Gravity gravity;
    public GameObject boom;

    private Rigidbody rb;
    public int ene_Hp = 5;
    bool player_check = false;

    private int Hp;
    float hp_up = 0;
    float move_plus = 0.0f;
    bool ene_move_on = true;
    int rand;

    // Start is called before the first frame update
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Hp = ene_Hp;
    }
    void Update()
    {
        if (move_plus < 3)
        {
            move_plus = move_plus + Time.deltaTime;
            ene_move_on = true;
        }
        else if (move_plus > 2)
        {
            rand = Random.Range(0, 4);
            move_plus = 0;
            ene_move_on = false;
        }

        if (ene_move_on != true)
        {
            switch (rand)
            {
                case 0: //멈춤

                    break;
                case 1: //앞으로
                    this.GetComponent<Rigidbody>().velocity = this.transform.forward * 20 + this.transform.up * 15;
                    break;
                case 2: //오른쪽
                    this.GetComponent<Transform>().eulerAngles = new Vector3(this.GetComponent<Transform>().eulerAngles.x + 90, this.GetComponent<Transform>().eulerAngles.y, this.GetComponent<Transform>().eulerAngles.z);
                    this.GetComponent<Rigidbody>().velocity = this.transform.forward * 20 + this.transform.up * 15;
                    break;
                case 3: //왼쪽
                    this.GetComponent<Transform>().eulerAngles = new Vector3(this.GetComponent<Transform>().eulerAngles.x - 90, this.GetComponent<Transform>().eulerAngles.y, this.GetComponent<Transform>().eulerAngles.z);
                    this.GetComponent<Rigidbody>().velocity = this.transform.forward * 20 + this.transform.up * 15;
                    break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (ene_Hp > 0)
                what_is.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (ene_Hp > 0)
            {
                what_is.transform.localScale = new Vector3(0, 0, 0);
                heart.transform.localScale = new Vector3(0, 0, 0);
            }
            Barrier.GetComponent<MeshRenderer>().material.color = new Color(Barrier.GetComponent<MeshRenderer>().material.color.r, Barrier.GetComponent<MeshRenderer>().material.color.g, Barrier.GetComponent<MeshRenderer>().material.color.b, 0);
            //ene_Hp = Hp;
            player_check = false;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player_check = true;
            if (ene_Hp < ene_Hp * 0.5)
            {
                Vector3 upgra = (this.transform.position - gravity.transform.position).normalized;
                this.transform.LookAt(target_player.transform.position, upgra);
            }
            if (ene_Hp <= 0)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 30);
                this.GetComponent<Rigidbody>().AddForce(this.transform.up * 15);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && other.tag == "Player" && ene_Hp <= 0)
        {
            what_is.transform.localScale = new Vector3(0, 0, 0);
            heart.transform.localScale = new Vector3(3, 3, 3);
            this.GetComponent<Animator>().SetTrigger("Hit");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && other.tag == "Player" && ene_Hp > 0)
        {
            this.GetComponent<Animator>().SetTrigger("Jump");
            float scale_what = 3.0f - ((float)ene_Hp * 0.3f);
            if (!boom.GetComponent<ParticleSystem>().isPlaying)
            {
                boom.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                boom.GetComponent<ParticleSystem>().Stop(true);
                boom.GetComponent<ParticleSystem>().Play();
            }
            what_is.transform.localScale = new Vector3(scale_what, scale_what, scale_what);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player_check == true)
        {
            ene_Hp--;
        }
        if (ene_Hp < Hp && ene_Hp > 0)
        {
            hp_up = hp_up + Time.deltaTime;
            if (hp_up > 1.5f)
            {
                ene_Hp++;
                hp_up = 0;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" && ene_Hp <= 0)
        {
            Barrier.GetComponent<MeshRenderer>().material.color = new Color(Barrier.GetComponent<MeshRenderer>().material.color.r, Barrier.GetComponent<MeshRenderer>().material.color.g, Barrier.GetComponent<MeshRenderer>().material.color.b, 0.4f);
        }
    }
}
