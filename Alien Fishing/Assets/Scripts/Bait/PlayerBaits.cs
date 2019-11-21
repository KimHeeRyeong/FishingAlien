using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaits : MonoBehaviour
{
    [SerializeField] BaitController[] baits;
    // Start is called before the first frame update
    public GameObject GetPlayerWearBait()
    {
        if (baits == null)
            return null;

        string playerBaitUID = DataSingleton.Instance.GetPlayerWearBait();
        string baitUID = DataSingleton.Instance.FindPlayerBait(playerBaitUID).baitID;

        int cnt = baits.Length;
        for(int i = 0; i < cnt; i++)
        {
            if (baits[i].GetUIDCODE() == baitUID)
            {
                return baits[i].gameObject;
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
