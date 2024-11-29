using System.Collections;
using UnityEngine;
using TMPro;

public class SceneControl : MonoBehaviour
{
    public GameObject fadeOutEffect;   // Objek efek Fade Out
    public TextMeshProUGUI textOpening;
    public GameObject panelOpening;   // Panel untuk teks opening
    public float letterDelay = 0.04f; // Waktu jeda antar huruf
    public GameObject charAria;       // Karakter Aria
    public GameObject charNaya;       // Karakter Naya
    public GameObject dialogueManager; // Dialog Manager

    private bool isTextFinished = false; // Menandai apakah teks sudah selesai
    private bool skipText = false;       // Menandai klik untuk melewati animasi teks
    private bool isTextActive = false;   // Menandai apakah teks opening sedang aktif
    private bool textHidden = false;     // Menandai apakah teks dan panel sudah disembunyikan

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
        if (textOpening != null && panelOpening != null)
        {
            panelOpening.SetActive(true);  // Tampilkan panel opening
            isTextActive = true;
            yield return ShowTextOneByOne(textOpening, 
                "10 Tahun Kemudian.... Terdapat seorang pengembara yang memiliki kemampuan sihir sedang berjalan mencari sebuah desa terdekat. Aria menuju desa Elmwood untuk dijadikan tempat untuk ia menetap dan beristirahat. Namun sesampainya di gerbang desa Elmwood.....");
        }

        // Tunggu hingga klik berikutnya untuk menyembunyikan teks dan panel
        yield return new WaitUntil(() => textHidden);

        // 3. Aktifkan karakter
        charAria.SetActive(true);
        yield return new WaitForSeconds(3);
        charNaya.SetActive(true);
        yield return new WaitForSeconds(2);

        // 4. Mulai Dialog
        ActivateObject(dialogueManager, true);
    }

    IEnumerator ShowTextOneByOne(TextMeshProUGUI textComponent, string message)
    {
        textComponent.text = ""; // Kosongkan teks terlebih dahulu
        textComponent.gameObject.SetActive(true);
        isTextFinished = false; // Reset status teks selesai

        for (int i = 0; i < message.Length; i++)
        {
            if (skipText)
            {
                textComponent.text = message; // Tampilkan seluruh teks
                break;
            }

            textComponent.text += message[i]; // Tambahkan huruf satu per satu
            yield return new WaitForSeconds(letterDelay);
        }

        isTextFinished = true; // Teks selesai ditampilkan
        skipText = false;      // Reset status skip
    }

    void Update()
    {
        // Deteksi input saat teks opening aktif
        if (isTextActive && Input.GetMouseButtonDown(0))
        {
            if (!isTextFinished)
            {
                skipText = true; // Langsung tampilkan seluruh teks
            }
            else if (!textHidden)
            {
                // Sembunyikan teks dan panel saat klik berikutnya
                textOpening.gameObject.SetActive(false);
                panelOpening.SetActive(false);
                isTextActive = false;
                textHidden = true;
            }
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
}
