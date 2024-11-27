using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI characterNameText;   // Text untuk nama karakter
    public TextMeshProUGUI dialogText;          // Text untuk dialog
    public Image characterImage;               // Gambar karakter
    public Animator characterAnimator;         // Animator karakter

    public DialogData dialogData;              // ScriptableObject untuk data dialog

    private int currentDialogIndex = 0;        // Index dialog yang sedang ditampilkan

    void Start()
    {
        ShowDialog(currentDialogIndex);
    }

    // Menampilkan dialog berdasarkan index
    void ShowDialog(int index)
    {
        if (index < dialogData.dialogLines.Length)
        {
            var line = dialogData.dialogLines[index];

            // Menampilkan nama karakter
            characterNameText.text = line.characterName;
            dialogText.text = line.dialogText;
            characterImage.sprite = line.characterSprite;

            // Menjalankan animasi berdasarkan trigger yang ditentukan
            if (!string.IsNullOrEmpty(line.animationTrigger))
            {
                characterAnimator.SetTrigger(line.animationTrigger);
            }
        }
    }

    // Fungsi untuk melanjutkan ke dialog berikutnya
    public void NextDialog()
    {
        currentDialogIndex++;
        if (currentDialogIndex < dialogData.dialogLines.Length)
        {
            ShowDialog(currentDialogIndex);
        }
        else
        {
            Debug.Log("Dialog selesai!");
        }
    }
}

