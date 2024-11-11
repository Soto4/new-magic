using UnityEngine;

public class ScreenSettings : MonoBehaviour
{
    public void SetFullscreen(bool isFullscreen)
    {
        if (isFullscreen)
        {
            Screen.SetResolution(1920, 1080, true); // Fullscreen dengan resolusi 1920x1080
            Debug.Log("Fullscreen diaktifkan dengan resolusi 1920x1080");
        }
        else
        {
            // Sesuaikan ukuran windowed agar tetap proporsional (16:9)
            Screen.SetResolution(1600, 900, false); // Windowed dengan resolusi 1600x900
            Debug.Log("Windowed diaktifkan dengan resolusi 1600x900");
        }
    }
}
