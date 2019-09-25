using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chldRmv : MonoBehaviour
{
    float dt = 0;
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (dt > 3) {
            rmvChld();
            dt = -999;
        }
    }

    void rmvChld() {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform allChildren = this.transform.GetChild(i).transform;
            GameObject.Destroy(allChildren.gameObject);
        }
    }
}
