using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDataSet : MonoBehaviour
{
    [SerializeField] GameObject ItemPrefab;
    [SerializeField] CoinController coinController;
    List<PlayerEnemy> playerEnemies = null;
    void Start()
    {
        Debug.Log("store start");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerEnemies == null)
        {
            playerEnemies = DataSingleton.Instance.GetPlayerEnemy();
            int cnt = playerEnemies.Count;
            for (int i = 0; i < cnt; i++)
            {
                GameObject obj = Instantiate(ItemPrefab, gameObject.transform);
                obj.GetComponent<SetSellItemData>().SetData("",playerEnemies[i].enemyID,coinController);
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            int cnt = transform.childCount;
            for (int i = 0; i<cnt; i++)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
            playerEnemies = null;
        }
    }
}
