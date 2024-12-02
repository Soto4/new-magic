using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    public float typingSpeed = 0.05f;   // Kecepatan pengetikan
    public string fullText;             // Teks penuh yang akan ditampilkan
    private string currentText = "";    // Teks yang sedang ditampilkan

    public TextMeshProUGUI textUI;      // TextMeshPro UI untuk menampilkan teks

    void Start()
    {
        StartCoroutine(TypeText());
    }

    // Coroutine untuk mengetik teks satu per satu
    private IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            currentText += letter;
            textUI.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Fungsi untuk skip mengetik saat diklik
    public void SkipTyping()
    {
        StopAllCoroutines();
        textUI.text = fullText;  // Langsung tampilkan seluruh teks
    }
}
