using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlanetScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            string uid = other.GetComponent<BasicEnemy>().GetEnemyID();
            GameSingleton.Instance.SetFishingEnemy(uid);
            GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
            sound_single.Instance.AllStop();
            SceneManager.LoadScene(1);
        }else if (other.CompareTag("Bait"))
        {
            GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
            sound_single.Instance.AllStop();
            SceneManager.LoadScene(1);
        }
        
    }
    private void OnTriggerStay(Collider other)
    {

    }
}
