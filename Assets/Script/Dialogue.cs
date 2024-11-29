using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent; // Untuk menampilkan nama karakter

    public string[] lines;
    public string[] characterNames; // Array untuk nama karakter
    public float textSpeed;
    private int index;

    public string nextSceneName; // Nama scene tujuan

    void Start()
    {
        nameComponent.text = string.Empty; // Reset nama karakter
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        DisplayCharacterName();
        StartCoroutine(typeline());
    }

    IEnumerator typeline()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            DisplayCharacterName(); // Update nama karakter
            StartCoroutine(typeline());
        }
        else
        {
            EndDialogue();
        }
    }

    void DisplayCharacterName()
    {
        if (index < characterNames.Length)
        {
            nameComponent.text = characterNames[index];
        }
        else
        {
            nameComponent.text = string.Empty;
        }
    }

    void EndDialogue()
    {
        Debug.Log("Dialogue Finished!");
        ChangeScene(); // Pindah ke scene berikutnya
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
