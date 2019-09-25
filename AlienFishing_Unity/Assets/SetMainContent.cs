using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMainContent : MonoBehaviour
{
    ScrollRect scrollRect;
    [SerializeField]
    RectTransform[] content;
    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
    }
    public void SetContent(int menu) {
        int contentCnt = content.Length;
        for(int i = 0; i < contentCnt; i++) {
            if (i == menu)
            {
                content[i].gameObject.SetActive(true);
                scrollRect.content = content[i];
            }
            else
            {
                content[i].gameObject.SetActive(false);
            }
        }
    }
}
