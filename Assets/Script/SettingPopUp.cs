using UnityEngine;

public class settingPopup : MonoBehaviour
{
    public GameObject settingsPopup; // Referensi ke panel setting

    // Fungsi untuk membuka popup setting
    public void OpenSettings()
    {
        settingsPopup.SetActive(true); // Aktifkan panel popup
        Time.timeScale = 0; // Pause game
        Debug.Log("Game paused");
    }

    // Fungsi untuk menutup popup setting
    public void CloseSettings()
    {
        settingsPopup.SetActive(false); // Nonaktifkan panel popup
        Time.timeScale = 1; // Resume game
        Debug.Log("Game resumed");
    }
}
