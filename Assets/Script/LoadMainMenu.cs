using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        // Memuat data game yang disimpan
        GameData data = GameSaveManager.LoadGame();

        if (data != null && !string.IsNullOrEmpty(data.currentScene))  // Memeriksa apakah data ada
        {
            Debug.Log("Loading saved scene: " + data.currentScene);  // Menampilkan nama scene yang dimuat
            SceneManager.LoadScene(data.currentScene);  // Memuat scene yang tersimpan
        }
       
    }
}
