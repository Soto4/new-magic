using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;       // TMP untuk nama karakter
    public TextMeshProUGUI dialogueText;  // TMP untuk teks dialog
    public DialogueData dialogueData;     // Data dialog

    public GameObject ariaImage;          // Gambar karakter Aria
    public GameObject nayaImage;          // Gambar karakter Naya
    public float animationDelay = 0.5f;   // Delay animasi masuk karakter

    private int currentIndex = 0;         // Indeks dialog saat ini
    private CharacterAnimator ariaAnim;
    private CharacterAnimator nayaAnim;

    void Start()
    {
        // Ambil komponen Animator untuk Aria dan Naya
        ariaAnim = ariaImage.GetComponent<CharacterAnimator>();
        nayaAnim = nayaImage.GetComponent<CharacterAnimator>();

        // Mulai dialog
        if (dialogueData != null)
        {
            StartDialogue();
        }
    }

    public void StartDialogue()
    {
        // Tampilkan gambar karakter bergerak masuk
        ariaAnim.MoveCharacter(); // Gerakkan Aria
        nayaAnim.MoveCharacter(); // Gerakkan Naya
        Invoke("ShowDialogue", animationDelay);
    }

    void ShowDialogue()
    {
        if (currentIndex < dialogueData.dialogues.Length)
        {
            // Tampilkan nama dan dialog karakter
            nameText.text = dialogueData.dialogues[currentIndex].characterName;
            dialogueText.text = dialogueData.dialogues[currentIndex].dialogueText;
        }
        else
        {
            EndDialogue(); // Jika dialog selesai
        }
    }

    public void NextDialogue()
    {
        currentIndex++; // Lanjutkan ke dialog berikutnya
        ShowDialogue();
    }

    private void EndDialogue()
    {
        nameText.text = ""; // Kosongkan nama karakter
        dialogueText.text = "Selesai."; // Tampilkan akhir dialog
    }

    void Update()
    {
        // Klik kiri untuk lanjut dialog
        if (Input.GetMouseButtonDown(0))
        {
            NextDialogue();
        }
    }
}
