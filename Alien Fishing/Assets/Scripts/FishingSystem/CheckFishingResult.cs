using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CheckFishingResult : MonoBehaviour
{
    [SerializeField] Text name;
    void Start()
    {
        string fishingResuit = GameSingleton.Instance.GetFishingEnemy();
        Debug.Log(gameObject.name +" "+ fishingResuit);
        if (fishingResuit == null)
        {
            gameObject.SetActive(false);
            return;
        }
        Enemy enemy = DataSingleton.Instance.GetEnemy(fishingResuit);
        DataSingleton.Instance.AddPlayerEnemy(fishingResuit);
        name.text = enemy.name;
        Time.timeScale = 0;
        GameSingleton.Instance.SetFishingEnemy(null);
        StartCoroutine(Hide());

    }
    IEnumerator Hide() {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
