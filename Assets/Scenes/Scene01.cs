using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01 : MonoBehaviour
{
     public GameObject charAria;
    public GameObject charEdgar;
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
        //event 1
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
        nextButton.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Edgar";
        textToSpeak = "Selamat datang, Penyihir Aria. Kami sangat berterima kasih atas kedatanganmu. Desa ini... sudah terlalu lama berada di bawah bayang-bayang Dorian";
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
    nextButton.SetActive(false);  // Nonaktifkan tombol "Next"
    textBox.SetActive(true);      // Tampilkan kotak teks
    charName.GetComponent<TMPro.TMP_Text>().text = "Aria";  // Nama karakter yang berbicara adalah Edgar
    textToSpeak = "Aku sudah mendengar tentang keadaan desa ini. Aku datang sesuai tugasku—untuk melindungi kalian. Apa yang harus kulakukan.";
    textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;  // Tampilkan teks dialog Edgar
    currentTexlength = textToSpeak.Length;  // Hitung panjang teks
    TextCreator.runTextPrint = true;  // Mulai animasi teks
    yield return new WaitForSeconds(0.05f);  // Jeda sejenak
    yield return new WaitForSeconds(1);  // Jeda 1 detik
    yield return new WaitUntil(() => textLength == currentTexlength);  // Tunggu sampai teks selesai ditampilkan
    yield return new WaitForSeconds(0.5f);  // Jeda setengah detik
    nextButton.SetActive(true);  // Aktifkan tombol "Next"
    evenPos = 2;  // Atur status ke event kedua selesai
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
}

}
    

