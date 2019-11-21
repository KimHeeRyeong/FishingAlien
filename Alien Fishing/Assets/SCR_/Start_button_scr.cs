using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Start_button_scr : MonoBehaviour,IPointerClickHandler
{
    public Image Fadein;
    float time = 0;
    float time_ = 1.0f;

    private void Awake()
    {
        //Fadein.canvasRenderer.SetAlpha(0.0f);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(fadeIn());
        GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
        sound_single.Instance.AllStop();
        SceneManager.LoadScene(1);
    }
    IEnumerator fadeIn()
    {
        Fadein.gameObject.SetActive(true);
        Color alp = Fadein.color;
        while (alp.a < 1.0f)
        {
            time += Time.deltaTime / time_;
            alp.a = time;
            Fadein.color = alp;
            yield return null;
        }
        yield return null;
    }
}
