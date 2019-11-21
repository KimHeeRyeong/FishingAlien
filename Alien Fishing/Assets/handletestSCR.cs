using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handletestSCR : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(handleturn());

    }

    IEnumerator handleturn()
    {
        this.transform.Rotate(0, 10, 0);
        yield return new WaitForSeconds(5);
        this.transform.Rotate(0, -10, 0);

    }
}
