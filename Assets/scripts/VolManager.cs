using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolManager : MonoBehaviour
{
    public Slider BGM;
    public AudioSource audio;

    private float bgm = 1f;

    void Start()
    {
        bgm =  PlayerPrefs.GetFloat("bgm", 1f);
        BGM.value = bgm;
        audio.volume = BGM.value;
        
    }

    public void SoundSlider()
    {
        audio.volume = BGM.value;

        bgm = BGM.value;
        PlayerPrefs.SetFloat("bgm", bgm);
    }

    void Update()
    {
        SoundSlider();
        
    }
}
