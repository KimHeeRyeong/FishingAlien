using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetData : MonoBehaviour
{
    [SerializeField] EnemyPrefabController enemyPrefabController = null;
    [SerializeField] Text nameData;
    [SerializeField] GameObject newFind;
    [SerializeField] Text coin;
    
    GameObject enemy = null;
    private void Awake()
    {
        if (GameSingleton.Instance != null)
        {
            string enemyUID = GameSingleton.Instance.GetFishingEnemy();
            if (enemyUID == null)
            {
                gameObject.SetActive(false);
                return;
            }
            Time.timeScale = 0;

            GameSingleton.Instance.SetUIState(GameSingleton.UIState.GET_FISH);
            enemy = enemyPrefabController.ActiveUID(enemyUID);
            enemy.SetActive(true);
            enemy.GetComponent<Animator>().SetTrigger("Run");
            Enemy enemyData = DataSingleton.Instance.GetEnemy(enemyUID);
            EnemyDetail detailData = DataSingleton.Instance.EnemyDetailDataFromEnemy(enemyUID);

            coin.text = enemyData.cost.ToString()+" UC";
            nameData.text = enemyData.name;

            if (detailData.gotPlayer)
                newFind.SetActive(false);
            else
                newFind.SetActive(true);

        }
    }
    private void Update()
    {
        if(GameSingleton.Instance!=null && GameSingleton.Instance.GetUIState() != GameSingleton.UIState.GET_FISH)
        {
            if (enemy != null)
            enemy.SetActive(false);

            gameObject.SetActive(false);
            Time.timeScale = 1f;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(enemy != null)
            enemy.SetActive(false);

            gameObject.SetActive(false);
            GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
            Time.timeScale = 1f;
        }
    }
}
