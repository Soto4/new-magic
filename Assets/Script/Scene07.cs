using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene07 : MonoBehaviour
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
        // Event 1
        yield return new WaitForSeconds(1);
        charAria.SetActive(true);
        yield return new WaitForSeconds(1);
        mainTextObject.SetActive(true);
        textToSpeak = "Setelah membantu beberapa warga desa, Aria kembali ke rumahnya dan mendapati Dorian muncul dalam mimpi buruknya, memberikan ancaman langsung";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTexlength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTexlength);
        yield return new WaitForSeconds(0.5f);
        charDorian.SetActive(true);
        yield return new WaitForSeconds(2);
        nextButton.SetActive(true);
        evenPos = 1;
    }

    IEnumerator EventOne()
    {
        nextButton.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Dorian";
        textToSpeak = "Kau benar-benar berusaha keras, ya, Aria? Membantu para penduduk desa itu, seolah-olah mereka bisa menyelamatkanmu. Kau pikir kekuatan mereka akan cukup untuk mengalahkanku?";
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
        charName.GetComponent<TMPro.TMP_Text>().text = "Dorian";
        textToSpeak = "Aku percaya pada mereka, Dorian. Mereka lebih kuat dari yang kau kira.";
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
        charName.GetComponent<TMPro.TMP_Text>().text = "Dorian";
        textToSpeak = "Mereka lemah. Setiap warga yang kau tolong hanya memberikanmu harapan palsu. Ketika mereka melihatmu gagal, mereka akan meninggalkanmu dalam kegelapan. Kau tak bisa menyelamatkan mereka semua.";
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
        textToSpeak = "Aku akan melakukan yang terbaik. Aku tidak akan membiarkanmu menghancurkan desa ini.";
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
        textToSpeak = "Kita lihat saja, Aria. Waktu terus berjalan. Dan ketika kau jatuh, aku akan ada di sana untuk menyaksikannya";
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
            SceneManager.LoadScene("Scene08");
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