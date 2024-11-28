using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueEntry
{
    public string characterName;
    public string dialogueText;
}

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue System/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public DialogueEntry[] dialogues;  // Array of DialogueEntry
}
