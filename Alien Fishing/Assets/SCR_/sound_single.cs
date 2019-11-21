using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_single : MonoBehaviour
{
    private static sound_single instance = null;
    public static sound_single Instance { get => instance; }

    #region audioSources
    [SerializeField] AudioSource back_music;
    [SerializeField] AudioSource back;
    [SerializeField] AudioSource start;
    [SerializeField] AudioSource click;
    [SerializeField] AudioSource box_on;
    [SerializeField] AudioSource box_off;
    [SerializeField] AudioSource landing;
    [SerializeField] AudioSource en_start;
    [SerializeField] AudioSource en_end;
    [SerializeField] AudioSource en_middle;
    [SerializeField] AudioSource coin;
    [SerializeField] AudioSource Fishing_up;
    [SerializeField] AudioSource Monster_question;
    [SerializeField] AudioSource Monster_run;
    [SerializeField] AudioSource Monster_stay;
    [SerializeField] AudioSource Monster_shout;
    [SerializeField] AudioSource Bait_onf;
    #endregion

    float volume = 0.5f;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SetVolume(volume);
        DontDestroyOnLoad(gameObject);
    }
    public void SetVolume(float volume) {

        volume = Mathf.Clamp01(volume);
        this.volume = volume;

        back_music.volume = volume;
        back.volume = volume;
        start.volume = volume;
        click.volume = volume;
        box_on.volume = volume;
        box_off.volume = volume;
        landing.volume = volume;
        en_start.volume = volume;
        en_end.volume = volume;
        en_middle.volume = volume;
        coin.volume = volume;
        Fishing_up.volume = volume;
        Monster_question.volume = volume;
        Monster_run.volume = volume;
        Monster_stay.volume = volume;
        Monster_shout.volume = volume;
        Bait_onf.volume = volume;
    }
    public void PlayBackgroundMusic() {
        if (!back_music.isPlaying)
            back_music.Play();
    }
    public void StopBackgroundMusic() {
        back_music.Stop();
    }
    public void PlayStart() {
        start.Play();
    }
    public void PlayClick() {
        click.Play();
    }
    public void PlayBack()
    {
        click.Play();
        back.Play();
    }
    public void PlayCoin()
    {
        coin.Play();
    }
    public void PlayLanding()
    {
        landing.Play();
    }
    public void PlayBoxOn()
    {
        box_on.Play();
    }
    public void PlayBoxOff() {
        box_off.Play();
    }
    public void PlayFishingUP() {
        Fishing_up.Play();
    }
    public void PlayM_q() { 
        Monster_question.Play();
    }
    public void PlayM_r()
    {
        Monster_run.Play();
    }
    public void PlayM_s()
    {
        Monster_stay.Play();
    }
    public void PlayM_shout()
    {
        Monster_shout.Play();
    }
    public void PlayBait_onf()
    {
        Bait_onf.Play();
    }    

    #region engine sound
    public void PlayEnStart() {
        if(!en_start.isPlaying)
            en_start.Play();
    }
    public bool IsPlayEnStart() {
        return en_start.isPlaying;
    }
    public void StopEnStart() {
        en_start.Stop();
    }
    public void PlayEnEnd() {
        if (!en_end.isPlaying)
            en_end.Play();
    }
    public void StopEnEnd()
    {
        en_end.Stop();
    }
    public void PlayEnMiddle() {
        if (!en_middle.isPlaying)
            en_middle.Play();
    }
    public bool IsPlayEnEnd() {
        return en_end.isPlaying;
    }
    public bool IsPlayEnMiddle()
    {
        return en_middle.isPlaying;
    }
    public void StopEnMiddle()
    {
        en_middle.Stop();
    }
    #endregion
    
    public float GetVolume()
    {
        return volume;
    }

    public void AllStop()
    {
        back_music.Stop();
        back.Stop();
        start.Stop();
        click.Stop();
        box_on.Stop();
        box_off.Stop();
        landing.Stop();
        en_start.Stop();
        en_end.Stop();
        en_middle.Stop();
        coin.Stop();
        Fishing_up.Stop();
        Monster_question.Stop();
        Monster_run.Stop();
        Monster_stay.Stop();
        Monster_shout.Stop();
        Bait_onf.Stop();
    }
    
}
