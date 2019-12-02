using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColEnemy : MonoBehaviour
{
    [SerializeField] FishingCable fisingCable;
    [SerializeField] GameObject bait;
    Transform colEnemy = null;
    BasicEnemy enemy = null;
    Rigidbody rd;
    CapsuleCollider capsuleCollider;
    BaitController baitController;
    [SerializeField]GameObject fade;
    Image fadeImage;
    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        fisingCable.SetBaitBind(true);
        baitController = GetComponent<BaitController>();

        if (fade != null)
            fadeImage = fade.GetComponent<Image>();
    }
    private void Update()
    {
    }
    private void LateUpdate()
    {
        if (colEnemy != null)
        {
            colEnemy.position = transform.position;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (colEnemy == null && collision.gameObject.CompareTag("Enemy"))
        {
            sound_single.Instance.PlayFishingUP();
            baitController.SetState(BaitController.BaitState.COL_ENEMY);
            rd.constraints -= RigidbodyConstraints.FreezePositionY;
            bait.SetActive(false);
            capsuleCollider.enabled = false;
            fisingCable.SetBaitBind(false);
            colEnemy = collision.transform;
            enemy = collision.transform.GetComponent<BasicEnemy>();
            enemy.SetFight();

            StartCoroutine(Next(colEnemy));
            StartCoroutine(FadeOut());
        }
    }
    IEnumerator Next(Transform enemy)
    {
        yield return new WaitForSeconds(2);

        string uid = enemy.GetComponent<BasicEnemy>().GetEnemyID();
        GameSingleton.Instance.SetFishingEnemy(uid);
        GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
        sound_single.Instance.AllStop();
        SceneManager.LoadScene(1);
    }

    IEnumerator FadeOut()
    {
        Color alp = fadeImage.color;
        alp.a = 0f;
        fadeImage.color = alp;
        fade.SetActive(true);
        while (alp.a <1f)
        {
            alp.a += Time.deltaTime*1.5f;
            fadeImage.color = alp;
            yield return Time.deltaTime;
        }
        yield return null;
    }
}