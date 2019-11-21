using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSceneSCR : MonoBehaviour
{
    public GameObject MainButtons = null; //메인 씬 메뉴 버튼 그룹

    public GameObject Sound_slider = null; //메인 씬 사운드 슬라이더 그룹
    public Text Sound_slider_text = null; //메인 씬 사운드 슬라이더 - VolumeText

    public GameObject BackgroundSpace = null; //메인 씬 백그라운드 space(Sphere)


    Slider slider = null;
    void Start()
    {
        if (Sound_slider.GetComponent<Slider>() == null)
            return;

        slider = Sound_slider.GetComponent<Slider>();
        
        Time.timeScale = 1;
        slider.value = sound_single.Instance.GetVolume() * slider.maxValue;
        sound_single.Instance.PlayBackgroundMusic();
    }

    void Update()
    {
        BackgroundSpace.transform.Rotate(0, 0, Time.deltaTime); //space z축 rotate
    }

    public void OnStartClick() //게임시작 버튼 - 연결 씬 : 우주선 씬
    {
        sound_single.Instance.AllStop();
        sound_single.Instance.PlayStart();
        GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
        SceneManager.LoadScene(1);
    }

    public void OnOptionClick() //옵션 버튼 - 사운드 볼륨 조절
    {
        sound_single.Instance.PlayClick();

        MainButtons.SetActive(false);
        Sound_slider.SetActive(true);      
    }

    public void OnBackClick() //옵션 내부에서 메인 메뉴로 돌아가기 버튼
    {
        sound_single.Instance.PlayBack();

        MainButtons.SetActive(true);
        Sound_slider.SetActive(false);
    }

    public void OnSoundVolumeChange() //사운드 볼륨값이 변경될 때(볼륨 수치 표시)
    {
        if (slider == null)
            return;

        int val = (int)slider.value;
        int maxVal = (int)slider.maxValue;
        Sound_slider_text.text = val + "/" + maxVal;

        float volum = (float)val/ maxVal;
        sound_single.Instance.SetVolume(volum);
    }

    public void OnExitClick() //게임 종료 버튼
    {
        sound_single.Instance.PlayClick();
        Application.Quit();
    }
}
