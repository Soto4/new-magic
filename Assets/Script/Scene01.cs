using System.Collections;
using UnityEngine;
using TMPro; // Untuk teks efek jika menggunakan TextMeshPro

public class SceneControl : MonoBehaviour
{
    public GameObject fadeOutEffect;   // Objek efek Fade Out
    public TextMeshProUGUI textOpening;
    public float lineSpacing = 1.5f; // Teks pembuka (dengan efek satu per satu)
    public GameObject charAria;        // Karakter Aria
    public GameObject charNaya;        // Karakter Naya
    public GameObject dialogueManager; // Dialog Manager
    public GameObject nextButton;      // Tombol Next untuk dialog

    private bool isDialogueNexted = false; // Untuk memantau apakah tombol Next ditekan

    void Start()
    {
        StartCoroutine(SceneSequence());
    }

    IEnumerator SceneSequence()
    {
        // 1. Fade Out Effect
        if (fadeOutEffect != null)
        {
            fadeOutEffect.SetActive(true); // Mengaktifkan efek Fade Out
            yield return new WaitForSeconds(2f); // Tunggu hingga efek selesai
            fadeOutEffect.SetActive(false); // Nonaktifkan efek
        }

        // 2. Text Opening muncul per kata
        if (textOpening != null)
        {
            yield return ShowTextOneByOne(textOpening, "10 Tahun Kemudian.... Terdapat seorang pengembara yang memiliki kemampuan sihir sedang berjalan mencari sebuah desa terdekat. Aria menuju desa Elmwood untuk dijadikan tempat untuk ia menetap dan berisitirahat. Namun sesampainya di gerbang desa Elmwood.....");
            yield return new WaitForSeconds(5); // Jeda setelah teks selesai
            textOpening.gameObject.SetActive(false); // Hilangkan teks opening
        }

        charAria.SetActive(true);
        yield return new WaitForSeconds(3);
        charNaya.SetActive(true);
        yield return new WaitForSeconds(2);


        // 4. Mulai Dialog
        ActivateObject(dialogueManager, true);

        // 5. Aktifkan Naya
        

        // Fungsi untuk efek teks muncul satu per satu
        IEnumerator ShowTextOneByOne(TextMeshProUGUI textComponent, string message)
        {
            textComponent.text = ""; // Kosongkan teks terlebih dahulu
            textComponent.gameObject.SetActive(true);

            foreach (char c in message)
            {
                textComponent.text += c; // Tambahkan huruf satu per satu
                yield return new WaitForSeconds(0.04f); // Waktu jeda antar huruf
            }
        }

        // Fungsi untuk mengaktifkan/menonaktifkan objek
        void ActivateObject(GameObject obj, bool isActive)
        {
            if (obj != null)
            {
                obj.SetActive(isActive);
            }
        }

        // Fungsi untuk mendeteksi tombol Next ditekan
    }
}
