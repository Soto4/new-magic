<<<<<<< HEAD
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Fungsi untuk memuat scene berdasarkan nama
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
>>>>>>> menu,cutscene,gameplay
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

<<<<<<< HEAD
    // Fungsi untuk keluar dari game
    public void QuitGame()
    {
        Debug.Log("Keluar dari game!"); // Untuk debugging di editor
        Application.Quit();
    }
=======

>>>>>>> menu,cutscene,gameplay
}
