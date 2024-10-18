using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene04 : MonoBehaviour
{
    public GameObject charAria;
    public GameObject charMaeva;
    public GameObject charKael;
    public GameObject charElly;
    public GameObject fadeOut;

    public GameObject textBox;

    [SerializeField] string textToSpeak;
    [SerializeField] int currentTexlength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] int evenPos = 0;
    [SerializeField] GameObject charName;
    [SerializeField] GameObject buttonAcc;
    [SerializeField] GameObject buttonDec;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Evenstarter());
    }

    void Update()
    {
        textLength = TextCreator.charCount;
    }

    IEnumerator Evenstarter()
    {
         yield return new WaitForSeconds(1);     
        fadeOut.SetActive(true);
        // Event 1: Aria tiba di tempat baru
        yield return new WaitForSeconds(1);
        charAria.SetActive(true);
        yield return new WaitForSeconds(1);
        mainTextObject.SetActive(true);
        textToSpeak = "Aria melihat seorang anak kecil bernama Elly, duduk di sudut desa dengan air mata di pipinya";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        charElly.SetActive(true); // Menampilkan karakter Maeva
        yield return new WaitForSeconds(2);
        nextButton.SetActive(true);
        evenPos = 1;
    }

    IEnumerator EventOne()
    {
        nextButton.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Aria";
        textToSpeak = "Elly, ada apa? Mengapa kau menangis?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        evenPos = 2;
    }

    IEnumerator EventTwo()
    {
        nextButton.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Elly";
        textToSpeak = "Kakakku... Kakakku terkena kutukan Dorian. Dia tidak bisa bangun dari tempat tidur. Tolong, bisakah kau menyelamatkannya? Ibu sudah mencoba semuanya, tapi tak ada yang berhasil.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        evenPos = 3;
    }

    IEnumerator EventThree()
    {
        nextButton.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Aria";
        textToSpeak = "Aku akan mencoba yang terbaik, Elly. Di mana rumahmu? Aku akan segera pergi ke sana.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        evenPos = 4;
    }

    IEnumerator EventFour()
    {
        nextButton.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Elly";
        textToSpeak = "Terima kasih, Aria. Tolong selamatkan kakakku.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        buttonAcc.SetActive(true);
        buttonDec.SetActive(true);
        // Tambahkan listener untuk buttonAcc dan buttonDec
        buttonAcc.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => MultiChoice(true));
        buttonDec.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => MultiChoice(false));
    }

    public void NextButton()
    {
        if (evenPos == 1)
        {
            StartCoroutine(EventOne());
        }
        else if (evenPos == 2)
        {
            StartCoroutine(EventTwo());
        }
        else if (evenPos == 3)
        {
            StartCoroutine(EventThree());
        }
        else if (evenPos == 4)
        {
            StartCoroutine(EventFour());
        }

    }
    public void MultiChoice(bool isAccepted)
    {
        if (isAccepted)
        {
            // Jika buttonAcc diklik (lanjut ke scene selanjutnya)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            // Jika buttonDec diklik (kembali ke scene sebelumnya)
            if (SceneManager.GetActiveScene().buildIndex > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}