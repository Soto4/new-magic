using System.Collections;
using UnityEngine;
using TMPro;

public class TextCreator : MonoBehaviour
{
    public static TMP_Text viewText;
    public static bool runTextPrint;
    public static int charCount;
    [SerializeField] private string transferText;
    [SerializeField] private int internalCount;

    private Coroutine typingCoroutine;

    private void Update()
    {
        internalCount = charCount;

        if (viewText != null)
        {
            charCount = viewText.text.Length;
        }

        if (runTextPrint && typingCoroutine == null)
        {
            runTextPrint = false; // Reset flag agar coroutine hanya dijalankan sekali
            if (viewText == null)
            {
                viewText = GetComponent<TMP_Text>();
            }
            transferText = viewText.text;
            viewText.text = ""; // Kosongkan teks sebelum mulai efek ketikan
            typingCoroutine = StartCoroutine(RollText());
        }
    }

    IEnumerator RollText()
    {
        foreach (char c in transferText)
        {
            if (!runTextPrint) // Jika runTextPrint diubah menjadi false, hentikan efek ketikan
            {
                viewText.text = transferText; // Tampilkan seluruh teks langsung
                break;
            }

            viewText.text += c;
            yield return new WaitForSeconds(0.03f);
        }

        typingCoroutine = null;
    }

    public static void SetText(TMP_Text targetText, string newText)
    {
        viewText = targetText;
        viewText.text = newText;
        charCount = 0;
        runTextPrint = true;
    }
}
