using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateUI : MonoBehaviour
{
    [SerializeField] GameObject openKey = null;
    [SerializeField] GameSingleton.UIState state;
    void Update()
    {
        if (GameSingleton.Instance.GetUIState() != state)
            gameObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Space))//off ui
        {
            GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
            sound_single.Instance.PlayBoxOff();
            Time.timeScale = 1;
            openKey.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
