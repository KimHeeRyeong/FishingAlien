using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSCR : MonoBehaviour
{
    public GameObject MenuPanel = null;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnToMain() //게임 메인 화면으로
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnResume() //게임 이어서
    {
        MenuPanel.SetActive(false);
    }

    public void OnExitGame() //게임 종료
    {
        Application.Quit();
    }
}

