using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    static Fade instance = null;
    static Fade Instance { get => instance; }
    [SerializeField] GameObject fade;
    [SerializeField] Color[] color;

    Image fadeImage;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        fadeImage = fade.GetComponent<Image>();
        fade.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void FadeIn(int sceneNum) {
        if (color.Length > sceneNum - 2)
            fadeImage.color = color[sceneNum - 2];
        

    }
    public void FadeOut() {


    }
   
    IEnumerator InCoroutine() {
        Color alp = fadeImage.color;
        alp.a = 1f;

        while (alp.a > 0f)
        {
            fadeImage.color = alp;
            alp.a -= Time.deltaTime;
            yield return Time.deltaTime;
        }
        fadeImage.gameObject.SetActive(false);
        yield return null;
    }
    IEnumerator OutCoroutine(){
        Color alp = fadeImage.color;
        alp.a = 0f;

        while (alp.a < 1f)
        {
            fadeImage.color = alp;
            alp.a += Time.deltaTime;
            yield return Time.deltaTime;
        }
        yield return null;
    }
}
