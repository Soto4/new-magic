using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Fungsi untuk memuat scene berdasarkan nama
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Fungsi untuk keluar dari game
    public void QuitGame()
    {
        Debug.Log("Keluar dari game!"); // Untuk debugging di editor
        Application.Quit();
    }
}
