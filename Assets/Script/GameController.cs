using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> btns = new List<Button>();
    private bool firstGuess, secondGuess;
    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuesspuzzle, secondGuessPuzzle;

    void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites");
    }


    void Start()
    {
        GetButtons();
        AddListener();
        AddGamePuzzle();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }

  void GetButtons()
{
    GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

    // Load Animator Controller dari folder Resources
    RuntimeAnimatorController animatorController = Resources.Load<RuntimeAnimatorController>("CardFlipController");

    for (int i = 0; i < objects.Length; i++)
    {
        Button button = objects[i].GetComponent<Button>();
        btns.Add(button);
        button.image.sprite = bgImage;

        // Tambahkan komponen Animator jika belum ada
        Animator animator = objects[i].GetComponent<Animator>();
        if (animator == null)
        {
            animator = objects[i].AddComponent<Animator>();
        }

        // Tetapkan Animator Controller
        animator.runtimeAnimatorController = animatorController;

        // Debugging: Pastikan Animator Controller berhasil ditambahkan
        if (animator.runtimeAnimatorController == null)
        {
            Debug.LogError($"Animator Controller tidak ditemukan untuk tombol: {objects[i].name}");
        }
        else
        {
            Debug.Log($"Animator Controller berhasil ditambahkan ke tombol: {objects[i].name}");
        }
    }
}


    void AddGamePuzzle()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if(index == looper/2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }
    void AddListener()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }
   public void PickAPuzzle()
{
    string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
    GameObject selectedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

    Animator animator = selectedButton.GetComponent<Animator>();
    if (!firstGuess)
    {
        firstGuess = true;
        firstGuessIndex = int.Parse(name);
        firstGuesspuzzle = gamePuzzles[firstGuessIndex].name;

        // Set animasi flip
        animator.SetBool("IsFlipped", true);
    }
    else if (!secondGuess)
    {
        secondGuess = true;
        secondGuessIndex = int.Parse(name);
        secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

        // Set animasi flip
        animator.SetBool("IsFlipped", true);

        countGuesses++;
        StartCoroutine(CheckIfThePuzzlesMatch());
    }
}

    IEnumerator CheckIfThePuzzlesMatch()
    {
        yield return new WaitForSeconds(1f);
            if (firstGuesspuzzle == secondGuessPuzzle)
            {
            yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            CheckIfTheGameIsFinish();
            } else
            {
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
            }
            yield return new WaitForSeconds(.5f);
        firstGuess = secondGuess = false;

    }
    void CheckIfTheGameIsFinish()
    {
        countCorrectGuesses++;
        if (countCorrectGuesses == gameGuesses)
        {
            Debug.Log("You Won!");
            Debug.Log("It Took You have " + countGuesses + " many Guesses to finish the game");
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0;  i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
   }


    
       
       
       
