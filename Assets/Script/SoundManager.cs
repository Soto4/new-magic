using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider; // Slider untuk musik
    [SerializeField] Slider sfxSlider;   // Slider untuk SFX

    void Start()
    {
        // Muat volume yang tersimpan atau gunakan nilai default
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 1);
        }

        Load();
    }

    // Dipanggil saat slider musik diubah
    public void ChangeMusicVolume()
    {
        AudioListener.volume = musicSlider.value;
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value); // Simpan volume musik
    }

    // Dipanggil saat slider SFX diubah
    public void ChangeSFXVolume()
    {
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value); // Simpan volume SFX
        // Kamu bisa mengatur volume SFX langsung pada AudioSource yang digunakan untuk efek suara di sini
        // Misalnya: sfxAudioSource.volume = sfxSlider.value;
    }

    private void Load()
    {
        // Atur slider ke nilai yang tersimpan
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        // Terapkan volume global dan SFX (jika ada AudioSource untuk SFX)
        AudioListener.volume = musicSlider.value;
        // Contoh: sfxAudioSource.volume = sfxSlider.value;
    }
}
