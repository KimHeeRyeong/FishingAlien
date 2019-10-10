using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_scr : MonoBehaviour
{
    public GameObject player;
    public GameObject get_ene;

    void Update()
    {
        get_ene = player.GetComponent<player_move_scr>().get_ene;
    }
    private void OnTriggerStay(Collider other)
    {
        if (get_ene == other.gameObject.GetComponent<Rigidbody>())
        {
            if (get_ene != null)
            {            
                other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(100.0f, player.transform.position, 5.0f);
            }
        }
    }
}
