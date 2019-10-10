using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Out_gra : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(3000.0f, collision.contacts[0].point, 5.0f);
            Debug.Log("hell year");
        }
    }
}
