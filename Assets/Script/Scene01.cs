using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01 : MonoBehaviour
{
    public GameObject charAria;
    public GameObject charEdgar;
    public GameObject textBox;
    public GameObject fadeOut;

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
        // Event 1
        yield return new WaitForSeconds(1);     
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        charAria.SetActive(true);
        yield return new WaitForSeconds(1);
        mainTextObject.SetActive(true);
        textToSpeak = "Aria tiba di desa Elmwood. Disambut kepala desa, Edgar.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        charEdgar.SetActive(true);
        yield return new WaitForSeconds(2);
        nextButton.SetActive(true);
        evenPos = 1;
    }

    IEnumerator EventOne()
    {
        nextButton.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Edgar";
        textToSpeak = "Selamat datang, Penyihir Aria. Kami sangat berterima kasih atas kedatanganmu. Desa ini... sudah terlalu lama berada di bawah bayang-bayang Dorian.";
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
        nextButton.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Aria";
        textToSpeak = "Aku sudah mendengar tentang keadaan desa ini. Aku datang sesuai tugasku untuk melindungi kalian. Apa yang harus kulakukan?";
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
        nextButton.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Edgar";
        textToSpeak = "Warga kami ketakutan. Dorian telah mengutuk sebagian besar dari kami. Terdapat banyak permintaan bantuan... Jika kau bisa menyelesaikan tugas mereka, mungkin kita bisa memperkuat sihir pelindung desa";
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
        nextButton.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Aria";
        textToSpeak = "Aku akan membantu sebanyak yang aku bisa. Apa kau bisa tunjukkan warga yang membutuhkan pertolongan?";
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
        nextButton.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Edgar";
        textToSpeak = "Ya... Tapi ingat, waktu kita terbatas. Dorian semakin mendekat. Jika kau tidak bisa membantu mereka, aku khawatir semuanya akan berakhir buruk";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        evenPos = 6; // End or continue to further events


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
        else if (evenPos == 6)
        {
            SceneManager.LoadScene("Scene02");
        }
    }
}
