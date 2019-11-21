using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSCR : MonoBehaviour
{
    public GameObject HelpPanel = null;
    // Start is called before the first frame update
    void Start()
    {
        HelpPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickHelpButton()
    {
        if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.NONE ||
            GameSingleton.Instance.GetUIState() == GameSingleton.UIState.DRIVE||
            GameSingleton.Instance.GetUIState() == GameSingleton.UIState.FISHING)
        {
            GameSingleton.Instance.SetUIState(GameSingleton.UIState.HELP);
            HelpPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void OnClickCloseButton()
    {
        HelpPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
