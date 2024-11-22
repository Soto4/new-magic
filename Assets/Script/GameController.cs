using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> btns = new List<Button>();

    private List<int> currentGuesses = new List<int>();
    private int cardsToMatch;
    private int correctMatches = 0;
    private int score = 0;

    [SerializeField] private Text scoreText;
    [SerializeField] private int currentRound = 1;
    [SerializeField] private GameObject winPopup;

    void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites");
    }

    void Start()
    {
        StartNewRound();
    }

    void StartNewRound()
    {
        ResetGame();
        cardsToMatch = currentRound + 2; // Ronde 1: 3 kartu, Ronde 2: 4 kartu, Ronde 3: 5 kartu
        GetButtons();
        AddGamePuzzle();
        Shuffle(gamePuzzles);
        scoreText.text = "Score: " + score;
    }

    void ResetGame()
    {
        gamePuzzles.Clear();
        btns.Clear();
        currentGuesses.Clear();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        foreach (GameObject obj in objects)
        {
            Button btn = obj.GetComponent<Button>();
            btn.image.sprite = bgImage;
            btn.interactable = true;
            btn.image.color = Color.white;
            btns.Add(btn);
        }
    }

    void GetButtons()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    void AddGamePuzzle()
    {
        for (int i = 0; i < btns.Count; i++)
        {
            gamePuzzles.Add(puzzles[i % puzzles.Length]);
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void PickAPuzzle()
    {
        int index = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Button btn = btns[index];

        if (!currentGuesses.Contains(index))
        {
            currentGuesses.Add(index);
            btn.image.sprite = gamePuzzles[index];

            if (currentGuesses.Count == cardsToMatch)
            {
                StartCoroutine(CheckIfThePuzzlesMatch());
            }
        }
    }

    IEnumerator CheckIfThePuzzlesMatch()
    {
        yield return new WaitForSeconds(1f);

        bool isMatch = true;
        string firstName = gamePuzzles[currentGuesses[0]].name;

        foreach (int index in currentGuesses)
        {
            if (gamePuzzles[index].name != firstName)
            {
                isMatch = false;
                break;
            }
        }

        if (isMatch)
        {
            foreach (int index in currentGuesses)
            {
                btns[index].interactable = false;
                btns[index].image.color = new Color(0, 0, 0, 0);
            }

            correctMatches++;
            if (correctMatches == btns.Count / cardsToMatch)
            {
                score++;
                currentRound++;
                if (currentRound > 3)
                {
                    WinGame();
                }
                else
                {
                    StartNewRound();
                }
            }
        }
        else
        {
            foreach (int index in currentGuesses)
            {
                btns[index].image.sprite = bgImage;
            }
        }

        currentGuesses.Clear();
    }

    void WinGame()
    {
        winPopup.SetActive(true);
        scoreText.text = "Congratulations! Final Score: " + score;
    }
}
