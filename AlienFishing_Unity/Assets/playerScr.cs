using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScr : MonoBehaviour
{
    public GameObject bullet = null;
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) 
            this.transform.eulerAngles -= this.transform.up;
        else if (Input.GetKey(KeyCode.D))
            this.transform.eulerAngles += this.transform.up;
        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(this.transform.forward);
        else if (Input.GetKey(KeyCode.S))
            this.transform.Translate(-this.transform.forward);

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f)) {
                Instantiate(bullet, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }
    }
}
