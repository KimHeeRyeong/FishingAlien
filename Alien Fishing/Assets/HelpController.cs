//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HelpController : MonoBehaviour
//{
//    [SerializeField] GameObject helpButton;
//    [SerializeField] GameObject helpPanel;

//    //Start is called before the first frame update
//    void Start()
//    {
//        helpPanel.SetActive(false);
//    }

//    //Update is called once per frame
//    void Update()
//    {

//        if (!DataSingleton.Instance.GetTutorial())
//        {
//            helpButton.SetActive(false);
//            return;
//        }

//        if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.NONE ||
//            GameSingleton.Instance.GetUIState() == GameSingleton.UIState.DRIVE ||
//         GameSingleton.Instance.GetUIState() == GameSingleton.UIState.FISHING)
//        {
//            helpButton.SetActive(true);
//        }
//        else
//        {
//            helpButton.SetActive(false);
//        }

//    }
//    public void OnClickHelpButton()
//    {
//        sound_single.Instance.PlayClick();
//        helpPanel.SetActive(true);
//        Time.timeScale = 0f;

//        if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.NONE ||
//            GameSingleton.Instance.GetUIState() == GameSingleton.UIState.DRIVE ||
//            GameSingleton.Instance.GetUIState() == GameSingleton.UIState.FISHING)
//        {
//            GameSingleton.Instance.SetUIState(GameSingleton.UIState.HELP);
//            helpPanel.SetActive(true);
//            Time.timeScale = 0f;
//        }

//    }

//    public void OnClickCloseButton()
//    {
//        sound_single.Instance.PlayBack();
//        GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
//        helpButton.SetActive(true);
//        helpPanel.SetActive(false);
//        Time.timeScale = 1f;
//    }
//}
