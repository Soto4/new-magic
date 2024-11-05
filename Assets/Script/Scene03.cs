using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene03 : MonoBehaviour
{
    public GameObject charAria;
    public GameObject charMaeva; // Karakter baru Maeva
    public GameObject charKael; // Karakter baru Maeva
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

          if (Input.anyKeyDown)
        {
            NextButton();

        }
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
        textToSpeak = "Aria bertemu Kael, seorang pengrajin yang kehilangan pekerjaannya karena alat-alatnya dihancurkan oleh kutukan Dorian";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        charKael.SetActive(true); // Menampilkan karakter Maeva
        yield return new WaitForSeconds(2);
        nextButton.SetActive(true);
        evenPos = 1;
    }

    IEnumerator EventOne()
    {
        nextButton.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Kael";
        textToSpeak = "Alat-alatku... Semua rusak karena kutukan itu. Aku tak bisa memperbaiki apa pun. Bagaimana aku bisa menolong desa jika aku sendiri tak punya apa-apa";
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
        charName.GetComponent<TMPro.TMP_Text>().text = "Aria";
        textToSpeak = "Kutukan ini bisa dipatahkan, tapi akan membutuhkan banyak energi sihir. Apakah kau memiliki bahan-bahan untuk memperbaikinya setelah itu";
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
        charName.GetComponent<TMPro.TMP_Text>().text = "Kael";
        textToSpeak = "Aku masih punya beberapa bahan mentah. Jika kau bisa menghilangkan kutukan, aku bisa mulai bekerja lagi. Tapi waktu kita tak banyak, dan desa ini butuh perlindungan sekarang";
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
        charName.GetComponent<TMPro.TMP_Text>().text = "Aria";
        textToSpeak = "Aku bisa melakukannya, tapi aku harus mempertimbangkan siapa yang paling membutuhkan bantuanku sekarang. Aku akan mencoba membantumu secepatnya";
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