using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToHitPoint : MonoBehaviour
{
    [SerializeField] int speed = 50;
    Vector3 hitPoint;
    [SerializeField] Color[] color;
    [SerializeField] Image fade;
    int sceneNum = -1;
    private void Awake()
    {
        fade.gameObject.SetActive(false);
    }
    public void SetHit(Vector3 hitPoint) {
        this.hitPoint = hitPoint;
    }
    public void SetNextScene(int num) {
        sceneNum = num;
    }
    private void Update()
    {
        if (sceneNum == -1)
            return;

        transform.LookAt(hitPoint);
        Vector3 dir = (hitPoint - transform.position).normalized;
        transform.position += dir * Time.deltaTime * speed;

        if (!fade.gameObject.activeSelf)
        {
            if (Vector3.Distance(hitPoint, transform.position) < speed)
            {
                fade.gameObject.SetActive(true);
                StartCoroutine(FadeOut(sceneNum));
            }
        }
    }
    IEnumerator FadeOut(int scene)
    {
        if (color.Length > scene-2)
            fade.color = color[scene - 2];

        Color alp = fade.color;
        alp.a = 0;
        fade.color = alp;

        while (alp.a < 1f)
        {
            if (Vector3.Distance(hitPoint, transform.position) < Time.deltaTime * speed)
            {
                alp.a = 1;
            }
            else
            {
                alp.a += Time.deltaTime;
            }
            fade.color = alp;
            yield return Time.deltaTime;
        }

        sound_single.Instance.AllStop();
        GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
        SceneManager.LoadScene(scene);
        yield return Time.deltaTime;
    }
}
