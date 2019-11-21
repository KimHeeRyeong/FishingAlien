using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveUI : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] GameSingleton.UIState state;
    private void Update()
    {
        if (GameSingleton.Instance.GetUIState() != GameSingleton.UIState.NONE)
            gameObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Space))//on ui
        {
            if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.NONE)
            {
                GameSingleton.Instance.SetUIState(state);
                sound_single.Instance.PlayBoxOff();
                ui.SetActive(true);
                gameObject.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }
}
