using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSoundVolume : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound.Play();
        float volume = sound_single.Instance.GetVolume();
        sound.volume = volume;
    }
}
