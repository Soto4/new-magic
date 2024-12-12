using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections; // Tambahkan ini untuk mengatur scene

public class CutsceneController : MonoBehaviour
{
    [System.Serializable]
    public class CutsceneStep
    {
        public Sprite image; // Gambar untuk step ini
        public string text; // Teks untuk step ini
    }

    public Image cutsceneImage; // Referensi ke Image
    public TextMeshProUGUI cutsceneText; // Referensi ke Text
    public CutsceneStep[] steps; // Array step cutscene
    public float typingSpeed = 0.05f; // Kecepatan animasi ketik
    public string nextSceneName; // Nama scene berikutnya

    private int currentStepIndex = 0; // Indeks step saat ini
    private bool isTyping = false; // Apakah teks sedang diketik
    private string fullText; // Teks penuh untuk step saat ini

    void Start()
    {
        ShowStep(0); // Tampilkan step pertama
         Audio.Instance.PlayMusic("Cutscenedorian");
    }

    public void ShowStep(int index)
    {
        if (index >= 0 && index < steps.Length)
        {
            currentStepIndex = index;
            cutsceneImage.sprite = steps[index].image;
            fullText = steps[index].text;
            cutsceneText.text = ""; // Kosongkan teks untuk typing
            StartCoroutine(TypeText());
        }
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        foreach (char c in fullText)
        {
            cutsceneText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Klik kiri mouse
        {
            if (isTyping)
            {
                // Skip typing dan tampilkan teks penuh
                StopAllCoroutines();
                cutsceneText.text = fullText;
                isTyping = false;
            }
            else
            {
                // Lanjut ke step berikutnya
                int nextStep = currentStepIndex + 1;
                if (nextStep < steps.Length)
                {
                    ShowStep(nextStep);
                }
                else
                {
                    LoadNextScene(); // Load scene berikutnya jika step selesai
                }
            }
        }
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Nama scene berikutnya belum diatur!");
        }
    }
}
