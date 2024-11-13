using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;

}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialoguelines = new List<DialogueLine>();

}


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
       public void TriggerDialogue()
       {
        DialogueManager.instance.StartDialogue(dialogue);
       }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Contoh: cek apakah objek yang masuk memiliki tag tertentu
        if (other.CompareTag("Maeva"))
        {
            Debug.Log("Player memasuki area trigger!");
        }
    }
}