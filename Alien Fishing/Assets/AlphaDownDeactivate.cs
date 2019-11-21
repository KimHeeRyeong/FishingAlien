using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaDownDeactivate : MonoBehaviour
{
    Text text;
    
    private void Awake()
    {
        text = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {

        if (GameSingleton.Instance.GetUIState() != GameSingleton.UIState.NONE)
        {
            text.color = Color.white;
            gameObject.SetActive(false);
        }else
        {
            float a = text.color.a;
            a -= Time.deltaTime;
            if (a <= 0)
            {
                text.color = Color.white;
                gameObject.SetActive(false);
            }
            else
            {
                text.color = new Color(1,1,1,a);
            }
        }
    }
}
