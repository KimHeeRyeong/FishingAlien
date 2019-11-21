using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseCursorSCR : MonoBehaviour
{
    public Texture2D CursorImage = null;
    public CursorMode Mode = CursorMode.Auto;
    public Vector2 Hotspot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        int SceneNumber = CurrentScene.buildIndex;
        if (SceneNumber == 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.MENU ||
            GameSingleton.Instance.GetUIState() == GameSingleton.UIState.STORE ||
            GameSingleton.Instance.GetUIState() == GameSingleton.UIState.COLLECTION ||
            GameSingleton.Instance.GetUIState() == GameSingleton.UIState.FISHING ||
            !DataSingleton.Instance.GetTutorial())
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }       
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(CursorImage, Hotspot, Mode);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, Mode);
    }
}
