using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public GameObject ariaImage; // Gambar karakter Aria
    public GameObject maevaImage; // Gambar karakter Maeva
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
    private Queue<DialogueLine> lines = new Queue<DialogueLine>();
    public bool isDialogueActive = false;
    public float typingSpeed = 0.05f;
    public float characterDisplayDelay = 0.5f; // Delay sebelum dialog muncul

    private void Start()
{
    if (instance == null)
        instance = this;
    else if (instance != this)
        Destroy(gameObject);

    lines = new Queue<DialogueLine>();

    // Debug untuk memastikan StartDialogue dipanggil
    Debug.Log("Mulai Dialog...");
    DisplayNextDialogueLine(someDialogue);  // Gantilah dengan dialog yang sudah ada
}

    public void DisplayNextDialogueLine()
{
    if (lines.Count == 0)
    {
        EndDialogue();
        return;
    }

    DialogueLine currentLine = lines.Dequeue();

    characterName.text = currentLine.character.name;

    if (currentLine.character.name == "Aria")
    {
        ariaImage.SetActive(true);
        maevaImage.SetActive(false);
        Debug.Log("Aria tampil");
    }
    else if (currentLine.character.name == "Maeva")
    {
        ariaImage.SetActive(false);
        maevaImage.SetActive(true);
        Debug.Log("Maeva tampil");
    }

    StopAllCoroutines();
    StartCoroutine(DisplayDialogueWithDelay(currentLine));
}

    IEnumerator DisplayDialogueWithDelay(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";  // Kosongkan area dialog sementara
        yield return new WaitForSeconds(characterDisplayDelay);

        // Tampilkan dialog secara bertahap
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        // Sembunyikan gambar karakter setelah dialog berakhir
        ariaImage.SetActive(false);
        maevaImage.SetActive(false);
    }
}
