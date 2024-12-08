using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSave : MonoBehaviour
{
    public void GoToMainMenu()
    {
        // Simpan progress game
        GameManager.Instance.SaveGame(SceneManager.GetActiveScene().name);

        // Muat ulang Main Menu sepenuhnya
        SceneManager.LoadScene("MainMenu");
    }
}
