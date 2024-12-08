using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSave : MonoBehaviour
{
    public void GoToMainMenu()
    {
        // Simpan nama scene saat ini
        GameManager.Instance.SaveGame(SceneManager.GetActiveScene().name);

        // Pindah ke scene Main Menu
        SceneManager.LoadScene("MainMenu");
    }
}
