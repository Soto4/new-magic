using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene02 : MonoBehaviour
{
    public GameObject charAria;
    public GameObject charMaeva; // Karakter baru Maeva
    public GameObject textBox;
        public GameObject fadeOut;


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
        charAria.SetActive(true);
        yield return new WaitForSeconds(1);
        mainTextObject.SetActive(true);
        textToSpeak = "Aria bertemu dengan Maeva, seorang petani yang putus asa. Ladangnya dilanda kutukan yang membuat tanahnya gersang";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        charMaeva.SetActive(true); // Menampilkan karakter Maeva
        yield return new WaitForSeconds(2);
        nextButton.SetActive(true);
        evenPos = 1;
    }

    IEnumerator EventOne()
    {
        nextButton.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Maeva";
        textToSpeak = "Ladangku... semuanya sudah mati. Aku tak bisa menanam apa pun. Keluargaku bergantung pada hasil panen ini. Bisakah kau membantuku?";
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
        textToSpeak = "Kutukan ini berasal dari sihir hitam Dorian. Aku bisa menghilangkannya, tapi butuh waktu dan energi. Apakah kau memiliki sesuatu yang bisa membantuku memulihkan kekuatanku setelahnya?";
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
        charName.GetComponent<TMPro.TMP_Text>().text = "Maeva";
        textToSpeak = "Tentu! Aku punya beberapa ramuan penyembuh yang kutanam sebelum kutukan ini datang. Itu yang tersisa... Aku akan memberikan semuanya padamu";
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
        textToSpeak = "Baik, aku akan melakukan yang terbaik";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        evenPos = 5;
    }

    IEnumerator EventFive()
    {
        nextButton.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Maeva";
        textToSpeak = "Portal itu sangat berbahaya, Aria. Hanya penyihir dengan kekuatan sepertimu yang bisa mendekatinya tanpa terluka.";
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
        else if (evenPos == 5)
        {
            StartCoroutine(EventFive());
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