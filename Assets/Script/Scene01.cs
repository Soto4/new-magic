using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

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
    private bool isTyping = false;
    private bool isTextComplete = false;
    private Coroutine typeCoroutine;
    private TMP_Text dialogueText;

    void Start()
    {
        dialogueText = textBox.GetComponent<TMP_Text>();
        StartCoroutine(EventStarter());
    }

    void Update()
    {
        // Jika ada input saat text sedang diketik
        if (Input.anyKeyDown)
        {
            if (isTyping)
            {
                // Skip animasi ketik dan tampilkan semua teks
                StopCoroutine(typeCoroutine);
                dialogueText.text = textToSpeak;
                isTyping = false;
                isTextComplete = true;
                nextButton.SetActive(true);
            }
            else if (isTextComplete)
            {
                // Lanjut ke dialog berikutnya
                NextButton();
            }
        }
    }

    IEnumerator EventStarter()
    {
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

    void StartDialog(string dialogText, string speakerName)
    {
        isTextComplete = false;
        textBox.SetActive(true);
        charName.GetComponent<TMP_Text>().text = speakerName;
        textToSpeak = dialogText;
        currentTextLength = textToSpeak.Length;

        // Mulai menampilkan teks kata per kata
        typeCoroutine = StartCoroutine(TypeWordByWord(dialogText));
    }

    IEnumerator TypeWordByWord(string text)
    {
        isTyping = true;
        dialogueText.text = "";
        string[] words = text.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            // Tambahkan spasi setelah kata kecuali untuk kata terakhir
            string wordToType = words[i] + (i < words.Length - 1 ? " " : "");

            foreach (char letter in wordToType)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.03f); // Kecepatan typing
            }

            // Jeda singkat setelah setiap kata
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;
        isTextComplete = true;
        nextButton.SetActive(true);
    }

    IEnumerator WaitForTextToFinish()
    {
        yield return new WaitUntil(() => isTextComplete);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator EventOne()
    {
        nextButton.SetActive(false);
        StartDialog("Selamat datang, Penyihir Aria. Kami sangat berterima kasih atas kedatanganmu. Desa ini... sudah terlalu lama berada di bawah bayang-bayang Dorian.", "Edgar");
        yield return WaitForTextToFinish();
        eventPos = 2;
    }

    IEnumerator EventTwo()
    {
        nextButton.SetActive(false);
        StartDialog("Aku sudah mendengar tentang keadaan desa ini. Aku datang sesuai tugasku untuk melindungi kalian. Apa yang harus kulakukan?", "Aria");
        yield return WaitForTextToFinish();
        eventPos = 3;
    }

    IEnumerator EventThree()
    {
        nextButton.SetActive(false);
        StartDialog("Warga kami ketakutan. Dorian telah mengutuk sebagian besar dari kami. Terdapat banyak permintaan bantuan... Jika kau bisa menyelesaikan tugas mereka, mungkin kita bisa memperkuat sihir pelindung desa", "Edgar");
        yield return WaitForTextToFinish();
        eventPos = 4;
    }

    IEnumerator EventFour()
    {
        nextButton.SetActive(false);
        StartDialog("Aku akan membantu sebanyak yang aku bisa. Apa kau bisa tunjukkan warga yang membutuhkan pertolongan?", "Aria");
        yield return WaitForTextToFinish();
        eventPos = 5;
    }

    IEnumerator EventFive()
    {
        nextButton.SetActive(false);
        StartDialog("Ya... Tapi ingat, waktu kita terbatas. Dorian semakin mendekat. Jika kau tidak bisa membantu mereka, aku khawatir semuanya akan berakhir buruk", "Edgar");
        yield return WaitForTextToFinish();
        eventPos = 6;
    }

    public void NextButton()
    {
        if (isTyping || !isTextComplete) return;

        nextButton.SetActive(false);

        switch (eventPos)
        {
            case 1:
                StartCoroutine(EventOne());
                break;
            case 2:
                StartCoroutine(EventTwo());
                break;
            case 3:
                StartCoroutine(EventThree());
                break;
            case 4:
                StartCoroutine(EventFour());
                break;
            case 5:
                StartCoroutine(EventFive());
                break;
            case 6:
                SceneManager.LoadScene("Scene02");
                break;
        }
    }
}