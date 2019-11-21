using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField, HideInInspector] Transform bait;
    public void SetBait(Transform bait)
    {
        this.bait = bait;
    }
    void Update()
    {
        if (bait == null)
        {
            gameObject.SetActive(false);
            return;
        }

        transform.position = new Vector3(bait.position.x, 0, bait.position.z);
    }
}
