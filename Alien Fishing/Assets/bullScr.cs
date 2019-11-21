using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullScr : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) 
            this.transform.eulerAngles -= transform.up;        
        if (Input.GetKey(KeyCode.D))        
            this.transform.eulerAngles += transform.up;
        
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100.0f)){
                Instantiate(bullet, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }
    }
}
