using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSCR : MonoBehaviour
{
    public GameObject MenuPanel = null;
    public Transform player = null;
    public Transform ship = null;
    public GameObject helpPanel = null;

    private void Update()
    {
        if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.HELP
            || GameSingleton.Instance.GetUIState() == GameSingleton.UIState.GET_FISH
            ||GameSingleton.Instance.GetUIState()==GameSingleton.UIState.TUTORIAL)
            return;

        Menu();
    }

    //ESC 메인 메뉴(설문조사/메인으로/이어서/도움말/게임 종료)
    public void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape)
            && MenuPanel.activeSelf == false)
        {
            Debug.Log("Menu On");
            GameSingleton.Instance.SetUIState(GameSingleton.UIState.MENU);
            MenuPanel.SetActive(true);
            Time.timeScale = 0f;
            sound_single.Instance.PlayBack();
        }

        else if (Input.GetKeyDown(KeyCode.Escape)
            && MenuPanel.activeSelf == true)
        {
            Debug.Log("Menu Off");
            OnResume();
        }
    }

    public void OnToMain() //게임 메인 화면으로
    {
        if (player != null)
        {
            GameSingleton.Instance.SetPlayerPos(player.position,player.rotation);
        }
        if (ship != null)
        {
            GameSingleton.Instance.SetShipPos(ship.position, ship.rotation);
        }
        sound_single.Instance.AllStop();
        sound_single.Instance.PlayLanding();
        GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void OnResume() //게임 이어서
    {
        sound_single.Instance.PlayBack();
        GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
        MenuPanel.SetActive(false);
        helpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnExitGame() //게임 종료
    {
        sound_single.Instance.PlayLanding();
        Application.Quit();
    }

    public void OnGoogleForm() //구글폼으로 이동 버튼
    {
        Application.OpenURL("https://docs.google.com/forms/d/1NibaiT-dPwW-XLSbATBRZc5W1aYlxGfd_CURjajq7gA/edit");
    }

    public void OnHelpButton() //도움말 보기 버튼
    {
        sound_single.Instance.PlayClick();
        helpPanel.SetActive(true);
    }

    public void OnHelpCloseButton() //도움말 끄기 버튼
    {
        sound_single.Instance.PlayBack();
        helpPanel.SetActive(false);
    }
}