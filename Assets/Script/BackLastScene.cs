using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    public void CloseSettings()
    {
        // Ambil nama scene terakhir dari PlayerPrefs
        string lastScene = PlayerPrefs.GetString("LastScene", "menu"); // Default ke "menu" jika data tidak ada
        Debug.Log("Kembali ke scene: " + lastScene);

        // Pindah ke scene terakhir
        SceneManager.LoadScene(lastScene);
    }
}
