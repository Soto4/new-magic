using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    private void Start()
    {
        // Load saved volume values
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f); // Default to 1 (max volume)
        _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);    // Default to 1 (max volume)

        // Apply the saved volumes at the start
        MusicVolume();
        SFXVolume();
    }

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
        float volume = _musicSlider.value;
        Audio.Instance.MusicVolume(volume);
        PlayerPrefs.SetFloat("MusicVolume", volume); // Save the value
    }

    public void SFXVolume()
    {
        float volume = _sfxSlider.value;
        Audio.Instance.SFXVolume(volume);
        PlayerPrefs.SetFloat("SFXVolume", volume); // Save the value
    }
}
