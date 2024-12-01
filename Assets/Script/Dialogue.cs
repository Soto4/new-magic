using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [System.Serializable]
    public struct DialogueLine
    {
        public string characterName; // Nama karakter
        [TextArea(2, 5)] public string dialogueText; // Teks dialog
    }

    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent;

    public DialogueLine[] dialogues; // Array dialog berbasis Struct
    public float textSpeed;
    private int index;

    public string nextSceneName;

    void Start()
    {
        nameComponent.text = string.Empty;
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == dialogues[index].dialogueText)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogues[index].dialogueText;
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        DisplayDialogue();
    }

    IEnumerator typeline()
    {
        foreach (char c in dialogues[index].dialogueText.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < dialogues.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            DisplayDialogue();
        }
        else
        {
            EndDialogue();
        }
    }

    void DisplayDialogue()
    {
        nameComponent.text = dialogues[index].characterName; // Tampilkan nama
        StartCoroutine(typeline());
    }

    void EndDialogue()
    {
        Debug.Log("Dialogue Finished!");
        ChangeScene();
    }

    void ChangeScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set!");
        }
    }
}
