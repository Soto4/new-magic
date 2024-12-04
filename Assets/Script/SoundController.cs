using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    public void ToggleMusic()
    {
        Audio.Instance.ToggleMusic();
    }
     public void ToggleSFX()
    {
        Audio.Instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        Audio.Instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        Audio.Instance.SFXVolume(_sfxSlider.value);
    }

}
