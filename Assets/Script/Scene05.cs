using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene05 : MonoBehaviour
{
    public GameObject charAria;
    public GameObject charDorian;
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
        textToSpeak = "Aria berjalan menuju tepi hutan ketika tiba-tiba kabut hitam muncul. Dari dalam kabut, muncul Dorian, penyihir hitam yang menghantui desa";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        charDorian.SetActive(true); // Menampilkan karakter Maeva
        yield return new WaitForSeconds(2);
        nextButton.SetActive(true);
        evenPos = 1;
    }

    IEnumerator EventOne()
    {
        nextButton.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Dorian";
        textToSpeak = "Ah... Jadi ini penyihir muda yang dikirim untuk menghentikanku? Kau pikir bisa melindungi desa ini? Sungguh usaha yang sia-sia";
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
        textToSpeak = "Aku tidak takut padamu, Dorian. Aku akan melindungi desa ini dengan kekuatanku, dan mereka yang ada di dalamnya";
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
        charName.GetComponent<TMPro.TMP_Text>().text = "Dorian";
        textToSpeak ="Warga desa itu? Mereka bahkan tak bisa menyelamatkan diri mereka sendiri. Kau akan melihat, Penyihir Aria. Ketika waktumu habis, mereka akan meninggalkanmu seperti daun yang tertiup angin.";
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
        textToSpeak = "Selama mereka percaya padaku, aku akan bertarung untuk mereka. Kau tidak akan bisa menghancurkan desa ini.";
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
        charName.GetComponent<TMPro.TMP_Text>().text = "Dorian";
        textToSpeak = "Kita lihat saja... Tapi ingat, penyihir muda, setiap kali kau gagal, kutukan ini akan semakin kuat. Waktu tidak ada di pihakmu";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        evenPos = 6;
    } // End or continue to further events



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
            SceneManager.LoadScene("Scene06");
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