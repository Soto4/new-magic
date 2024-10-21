using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scene01 : MonoBehaviour
{
    public GameObject charAria;
    public GameObject charEdgar;
    public GameObject textBox;
    public GameObject fadeOut;

    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject charName;

    private int eventPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EventStarter());
    }

    void Update()
    {
        textLength = TextCreator.charCount;

        // Deteksi jika ada input keyboard untuk melanjutkan dialog
        if (Input.anyKeyDown)
        {
            NextButton();
        }
    }

    IEnumerator EventStarter()
    {
        // Event 1
        yield return new WaitForSeconds(1);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        charAria.SetActive(true);
        yield return new WaitForSeconds(1);
        mainTextObject.SetActive(true);

        StartDialog("Aria tiba di desa Elmwood. Disambut kepala desa, Edgar.", "Aria");
        yield return WaitForTextToFinish();
        
        charEdgar.SetActive(true);
        yield return new WaitForSeconds(2);
        nextButton.SetActive(true);
        eventPos = 1;
    }

    // Memulai dialog baru
    void StartDialog(string dialogText, string speakerName)
    {
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = speakerName;
        textToSpeak = dialogText;
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
    }

    // Menunggu sampai teks selesai ditampilkan
    IEnumerator WaitForTextToFinish()
    {
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
    }

    // Masing-masing event cerita
    IEnumerator EventOne()
    {
        StartDialog("Selamat datang, Penyihir Aria. Kami sangat berterima kasih atas kedatanganmu. Desa ini... sudah terlalu lama berada di bawah bayang-bayang Dorian.", "Edgar");
        yield return WaitForTextToFinish();
        nextButton.SetActive(true);
        eventPos = 2;
    }

    IEnumerator EventTwo()
    {
        StartDialog("Aku sudah mendengar tentang keadaan desa ini. Aku datang sesuai tugasku untuk melindungi kalian. Apa yang harus kulakukan?", "Aria");
        yield return WaitForTextToFinish();
        nextButton.SetActive(true);
        eventPos = 3;
    }

    IEnumerator EventThree()
    {
        StartDialog("Warga kami ketakutan. Dorian telah mengutuk sebagian besar dari kami. Terdapat banyak permintaan bantuan... Jika kau bisa menyelesaikan tugas mereka, mungkin kita bisa memperkuat sihir pelindung desa", "Edgar");
        yield return WaitForTextToFinish();
        nextButton.SetActive(true);
        eventPos = 4;
    }

    IEnumerator EventFour()
    {
        StartDialog("Aku akan membantu sebanyak yang aku bisa. Apa kau bisa tunjukkan warga yang membutuhkan pertolongan?", "Aria");
        yield return WaitForTextToFinish();
        nextButton.SetActive(true);
        eventPos = 5;
    }

    IEnumerator EventFive()
    {
        StartDialog("Ya... Tapi ingat, waktu kita terbatas. Dorian semakin mendekat. Jika kau tidak bisa membantu mereka, aku khawatir semuanya akan berakhir buruk", "Edgar");
        yield return WaitForTextToFinish();
        nextButton.SetActive(true);
        eventPos = 6;
    }

    // Fungsi untuk tombol Next atau input keyboard
    public void NextButton()
    {
        nextButton.SetActive(false); // Matikan tombol agar tidak bisa ditekan berulang kali

        if (eventPos == 1)
        {
            StartCoroutine(EventOne());
        }
        else if (eventPos == 2)
        {
            StartCoroutine(EventTwo());
        }
        else if (eventPos == 3)
        {
            StartCoroutine(EventThree());
        }
        else if (eventPos == 4)
        {
            StartCoroutine(EventFour());
        }
        else if (eventPos == 5)
        {
            StartCoroutine(EventFive());
        }
        else if (eventPos == 6)
        {
            SceneManager.LoadScene("Scene02");
        }
    }
}
