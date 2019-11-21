using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image Fadein;
    float time =1;
    float time_ = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator fadeIn()
    {
        Fadein.gameObject.SetActive(true);
        Color alp = Fadein.color;
        alp.a = 1f;
        while (alp.a > 0f)
        {
            Fadein.color = alp;
            alp.a -= Time.deltaTime;
            yield return Time.deltaTime;
        }
        Fadein.gameObject.SetActive(false);
        yield return null;
    }
}
