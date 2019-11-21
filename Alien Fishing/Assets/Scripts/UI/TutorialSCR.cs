using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSCR : MonoBehaviour
{
    public GameObject TutorialText1 = null;
    public Text TutorialText2 = null;
    public GameObject RightButton = null;
    public GameObject CloseButton = null;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!DataSingleton.Instance.GetTutorial())
        {
            GameSingleton.Instance.SetUIState(GameSingleton.UIState.TUTORIAL);
            Time.timeScale = 0f;
            TutorialText1.SetActive(true);
            RightButton.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickRightButton()
    {
        sound_single.Instance.PlayClick();
        TutorialText1.SetActive(false);
        TutorialText2.enabled = true;
        RightButton.SetActive(false);
        CloseButton.SetActive(true);
    }

    public void OnClickCloseButton()
    {
        sound_single.Instance.PlayBack();
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        DataSingleton.Instance.TutorialComplete();
        GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
    }
}
