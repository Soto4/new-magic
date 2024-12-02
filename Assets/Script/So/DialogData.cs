using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogLine
{
    public string characterName;        // Nama karakter yang berbicara
    public string dialogText;           // Teks dialog
    public Sprite characterSprite;     // Gambar karakter yang berbicara
    public string animationTrigger;    // Trigger untuk animasi karakter
}

[CreateAssetMenu(fileName = "NewDialog", menuName = "ScriptableObjects/DialogData")]
public class DialogData : ScriptableObject
{
    public DialogLine[] dialogLines;   // Array yang berisi semua dialog
}

