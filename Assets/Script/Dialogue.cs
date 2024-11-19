using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent;
    public string[] characterNames;
    public string[] lines;
    public float textSpeed;

    private int index;
    private bool isTyping;

    void Start()
    {
        this.enabled = false;
    }

    void OnEnable()
    {
        StartDialogue();
    }

    void Update()
{
    if (Input.GetMouseButtonDown(0) || Input.anyKeyDown)
    {
        Debug.Log("Input terdeteksi");
        if (isTyping)
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
            isTyping = false;
        }
        else
        {
            NextLine();
        }
    }
}


    void StartDialogue()
    {
        index = 0;
        DisplayCharacterName();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textComponent.text = "";
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
    }

    void NextLine()
{
    if (index < lines.Length - 1)
    {
        index++;
        Debug.Log($"Pindah ke baris: {index}, Isi: {lines[index]}");
        textComponent.text = string.Empty;
        DisplayCharacterName();
        StartCoroutine(TypeLine());
    }
    else
    {
        Debug.Log("Dialog selesai!");
        textComponent.text = ""; // Kosongkan teks jika dialog selesai
        nameComponent.text = ""; // Kosongkan nama jika dialog selesai
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
            nameComponent.text = "";
        }
    }
}
