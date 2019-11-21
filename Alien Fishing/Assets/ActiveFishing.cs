//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class ActiveFishing : MonoBehaviour
//{
//    [SerializeField] GameObject player;
//    [SerializeField] GameObject bait;
//    [SerializeField] GameObject camPlaeyr;

//    [SerializeField] GameObject text;
//    [SerializeField] string str;
//    [SerializeField] KeyCode key;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            text.GetComponent<Text>().text = str;
//            text.SetActive(true);
//        }
//    }
//    private void OnTriggerStay(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            if (!text.activeSelf)
//            {
//                text.SetActive(true);
//            }
//            else
//            {
//                if (Input.GetKey(key))
//                {
//                    Ray ray = new Ray();
//                    ray.origin = transform.position;
//                    ray.direction = transform.forward;
//                    RaycastHit hit;
//                    if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 1000))
//                    {
//                        if (hit.transform.CompareTag("Planet"))
//                        {
//                            bait.transform.position = player.transform.position + player.transform.forward * 100;
//                            bait.GetComponent<BaitColPlanet>().SetToPos(hit.point);
//                            bait.SetActive(true);
//                            camPlaeyr.SetActive(false);
//                        }
//                    }
//                }
//            }

//        }
//    }
//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//            text.SetActive(false);
//    }
//}
