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
    public GameObject charEldran;     // Karakter Eldran
    public GameObject charMaeva;     // Karakter Maeva
    public GameObject dialogueManager; // Dialog Manager

    private bool isTextFinished = false; // Menandai apakah teks sudah selesai
    private bool skipText = false;       // Menandai klik untuk melewati animasi teks
    private bool isTextActive = false;   // Menandai apakah teks opening sedang aktif
    private bool textHidden = false;     // Menandai apakah teks dan panel sudah disembunyikan
    private int currentSegment = 0;      // Menandai segmen teks yang sedang aktif

    private string[] openingSegments = new string[] // Teks dibagi menjadi beberapa segmen
    {
        "Terdapat seorang penyihir pengembara yang sedang berjalan mencari sebuah desa terdekat.",
        "Penyihir pengembara tersebut bernama Aria, Aria menuju desa Elmwood untuk dijadikan tempat untuk ia menetap dan berisitirahat.",
        "Namun sesampainya di gerbang desa Elmwood, ia bertemu seorang anak kecil yang kelihatannya sedang mencari sesuatu."
    };

    void Start()
    {
        StartCoroutine(SceneSequence());
         Audio.Instance.PlayMusic("Default");
    }

    IEnumerator SceneSequence()
    {
        // 1. Fade Out Effect
        if (fadeOutEffect != null)
        {
           fadeOutEffect.SetActive(true);
        yield return new WaitForSeconds(0);
        }

        // 2. Tampilkan teks opening berdasarkan segmen
        if (textOpening != null && panelOpening != null)
        {
            panelOpening.SetActive(true);  // Tampilkan panel opening
            isTextActive = true;

            while (currentSegment < openingSegments.Length)
            {
                yield return ShowTextOneByOne(textOpening, openingSegments[currentSegment]);
                yield return new WaitUntil(() => textHidden); // Tunggu hingga klik untuk segmen berikutnya
                textHidden = false; // Reset untuk segmen berikutnya
                currentSegment++;   // Pindah ke segmen berikutnya
            }
        }

        // 3. Aktifkan karakter
        charAria.SetActive(true);
        yield return new WaitForSeconds(0);
        charNaya.SetActive(true);
        yield return new WaitForSeconds(0);
        charEldran.SetActive(true);
        yield return new WaitForSeconds(0);
        charMaeva.SetActive(true);
        yield return new WaitForSeconds(1);
        charEldran.SetActive(true);
        yield return new WaitForSeconds(1);

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
                textHidden = true; // Tandai untuk menampilkan segmen berikutnya
                if (currentSegment >= openingSegments.Length - 1)
                {
                    // Jika segmen terakhir, sembunyikan teks dan panel
                    textOpening.gameObject.SetActive(false);
                    panelOpening.SetActive(false);
                    isTextActive = false;
                }
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
