using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaitColPlanet : MonoBehaviour
{
    Vector3 pos;
    public Image Fadein;
    float time = 0;
    float time_ = 1;
    float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (pos - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Planet"))
        {
            StartCoroutine(fadeIn());
            
        }
    }
    public void SetToPos(Vector3 p) {
        pos = p;
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
        yield return new WaitForSeconds(0.1f);
        sound_single.Instance.AllStop();
        SceneManager.LoadScene(2);
    }
}
