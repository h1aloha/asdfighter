using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider soundSliderSE;
    public Slider soundSliderMusic;
    public AudioMixer se, music;

    private void Start()
    {
        SetVolumeSE(PlayerPrefs.GetFloat("SavedSE", 100));
        SetVolumeMusic(PlayerPrefs.GetFloat("SavedMusic", 100));
    }

    public void SetVolumeSE(float _value)
    {
        if (_value < 1)
        {
            _value = .001f;
        }

        RefreshSliderSE(_value);
        PlayerPrefs.SetFloat("SavedSE", _value);
        se.SetFloat("SE", Mathf.Log10(_value/100*20));
    }

    public void SetVolumeMusic(float _value)
    {
        if (_value < 1)
        {
            _value = .001f;
        }

        RefreshSliderMusic(_value);
        PlayerPrefs.SetFloat("SavedMusic", _value);
        music.SetFloat("Music", Mathf.Log10(_value / 100 * 20));
    }

    public void SetVolumeFromSliderSE()
    {
        SetVolumeSE(soundSliderSE.value);
    }

    public void SetVolumeFromSliderMusic()
    {
        SetVolumeMusic(soundSliderMusic.value);
    }

    public void RefreshSliderSE(float _value)
    {
        soundSliderSE.value = _value;
    }

    public void RefreshSliderMusic(float _value)
    {
        soundSliderMusic.value = _value;
    }
}
