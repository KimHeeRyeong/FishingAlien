using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    float x, z;
    float speed = 10;
    float MouseX, MouseY;
    public GameObject move;
    public Camera main;
    public Camera sub_came;
    public GameObject ship_grass;
    public GameObject ship_booster;

    float MouseX_save;
    public GameObject Coin_ui;

    private void Awake()
    {
    }
    private void FixedUpdate()
    {
        if (move.transform.tag == "Player") //플레어 무브
        {
            main.transform.Rotate(Vector3.left * MouseY);
            Coin_ui.SetActive(true);

            speed = 90;
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            Rigidbody rd = move.GetComponent<Rigidbody>();

            Vector3 locVel = transform.InverseTransformDirection(rd.velocity);
            locVel = new Vector3(locVel.x * 0.8f, locVel.y, locVel.z * 0.8f);//add horizontal drag
            rd.velocity = transform.TransformDirection(locVel);

            if (rd.velocity.magnitude > 10)
                return;

            rd.AddRelativeForce(new Vector3(x, 0, z).normalized * Time.deltaTime * speed, ForceMode.Impulse);

            ship_grass.SetActive(false);
            ship_booster.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        //카메라 회전
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        move.transform.Rotate(Vector3.up * MouseX);

        /*
        if (move.transform.tag == "Player") //플레어 무브
        {
            speed = 400;
            

            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            Vector3 dir = transform.TransformVector(new Vector3(x, 0, z));
            Rigidbody moveRd = move.transform.GetComponent<Rigidbody>();
            Vector3 locVel = transform.InverseTransformDirection(moveRd.velocity);
            moveRd.velocity = dir.normalized * speed * Time.deltaTime + locVel.y * transform.up;
        }
        else*/ if (move.transform.tag == "Ship") //비행선 무브
        {

            speed = 100;
            move.transform.Rotate(Vector3.left * MouseY);
            Coin_ui.SetActive(false);

            ship_grass.SetActive(true);
            ship_booster.SetActive(true);

            //우주선 부스터
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                if (sub_came.fieldOfView < 150)
                {
                    sub_came.fieldOfView += Time.deltaTime * 50;
                }
                if (!sound_single.Instance.IsPlayEnStart())
                    sound_single.Instance.PlayEnMiddle();
                if (sub_came.fieldOfView > 145)
                { speed = 750; }
                if (sub_came.transform.localPosition.z < 170)
                {
                    sub_came.transform.localPosition = new Vector3(0, 30, sub_came.transform.localPosition.z + Time.deltaTime * 300);
                }
            }
            else
            {
                if (sub_came.fieldOfView > 60)
                {
                    sub_came.fieldOfView -= Time.deltaTime * 100;
                }
                sound_single.Instance.StopEnStart();
                if (sub_came.fieldOfView < 65)
                {
                    speed = 100;
                }

                if (sub_came.transform.localPosition.z > -375)
                {
                    sub_came.transform.localPosition = new Vector3(0, 130, sub_came.transform.localPosition.z - Time.deltaTime * 300);
                }
            }

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                if (sound_single.Instance.IsPlayEnMiddle())
                {
                    sound_single.Instance.PlayEnStart();
                    sound_single.Instance.StopEnEnd();
                }

            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKeyUp(KeyCode.W))
            {
                if (sound_single.Instance.IsPlayEnMiddle())
                {
                    sound_single.Instance.StopEnMiddle();
                    sound_single.Instance.PlayEnEnd();
                }
            }
            x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            move.transform.Translate(x, 0, z);
        }
    }
}