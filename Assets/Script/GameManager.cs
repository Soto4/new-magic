using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton untuk akses global
    private string lastScene; // Menyimpan nama scene terakhir

    private void Awake()
    {
        // Pastikan GameManager adalah Singleton
        if (Instance == null)
        {
            Instance = this;

            // Pastikan GameObject adalah root sebelum menggunakan DontDestroyOnLoad
            if (transform.parent == null)
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning("GameManager must be a root GameObject to use DontDestroyOnLoad!");
            }
        }
        else
        {
            Destroy(gameObject); // Hanya satu GameManager yang boleh ada
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            UpdateMainMenuButtons();
        }
    }

  private void UpdateMainMenuButtons()
{
    // Mencari tombol dengan nama "LoadButton"
    Button loadButton = GameObject.Find("LoadButton")?.GetComponent<Button>();

    if (loadButton != null)
    {
        loadButton.onClick.RemoveAllListeners(); // Hapus listener lama
        loadButton.onClick.AddListener(LoadGame); // Menghubungkan tombol dengan LoadGame
        Debug.Log("Load button updated and ready to use.");
    }
    else
    {
        // Jika tombol tidak ditemukan, beri tahu di Console
        Debug.LogError("Load button not found in Main Menu!");
    }
}


    public void SaveGame(string currentScene)
    {
        lastScene = currentScene;
        PlayerPrefs.SetString("LastScene", lastScene);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("LastScene"))
        {
            string sceneToLoad = PlayerPrefs.GetString("LastScene");
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void GoToMainMenu()
    {
        SaveGame(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainMenu");
    }
}
