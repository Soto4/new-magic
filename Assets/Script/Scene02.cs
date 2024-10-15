using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene02 : MonoBehaviour
{
    public GameObject charAria;
    public GameObject charMaeva; // Karakter baru Maeva
    public GameObject textBox;

    [SerializeField] string textToSpeak;
    [SerializeField] int currentTexlength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] int evenPos = 0;
    [SerializeField] GameObject charName;

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
        // Event 1: Aria tiba di tempat baru
        yield return new WaitForSeconds(1);
        charAria.SetActive(true);
        yield return new WaitForSeconds(1);
        mainTextObject.SetActive(true);
        textToSpeak = "Aria tiba di lembah Faelan, sebuah tempat yang dipenuhi dengan energi magis.";
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
        textToSpeak = "Selamat datang di Faelan, Aria. Aku Maeva, penjaga lembah ini.";
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
        textToSpeak = "Terima kasih, Maeva. Aku merasa kehadiran magis di sini sangat kuat. Apakah sesuatu yang penting terjadi?";
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
        textToSpeak = "Energi yang kamu rasakan berasal dari portal kuno di lembah ini. Sesuatu tampaknya terjadi di dalamnya.";
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
        textToSpeak = "Aku akan melihat portal tersebut. Apakah ada sesuatu yang perlu aku ketahui sebelum mendekatinya?";
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
        nextButton.SetActive(true);
        evenPos = 6;
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
}