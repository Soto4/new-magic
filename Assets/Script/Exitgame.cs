using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        // Fungsi keluar dari game
        #if UNITY_EDITOR
            // Jika sedang di Editor Unity
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Jika di build (Windows, Mac, dll.)
            Application.Quit();
        #endif
    }
}
