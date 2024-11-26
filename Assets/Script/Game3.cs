using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController7 : MonoBehaviour
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

    // Timer variables
    public float gameTime = 60f; // Waktu dalam detik
    private float remainingTime;
    public Text timerText; // UI Text untuk waktu
    public GameObject gameOverPanel; // Panel untuk Game Over
    public GameObject successPanel; // Panel untuk Success

    void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites");
    }

    void Start()
    {
        remainingTime = gameTime;
        gameOverPanel.SetActive(false);
        successPanel.SetActive(false);
        GetButtons();
        AddListener();
        AddGamePuzzle();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else if (!gameOverPanel.activeSelf) // Pastikan hanya dipanggil sekali
        {
            GameOver();
        }
    }

    void UpdateTimerUI()
    {
        timerText.text = "Time: " + Mathf.Ceil(remainingTime).ToString() + "s";
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
            btns[i].name = i.ToString(); // Tetapkan nama sesuai indeks
        }
    }

    void AddGamePuzzle()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
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
        // Mendapatkan nama tombol yang diklik
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject?.name;

        if (string.IsNullOrEmpty(name))
        {
            Debug.LogError("Selected GameObject's name is null or empty!");
            return;
        }

        if (!int.TryParse(name, out int selectedIndex) || selectedIndex < 0 || selectedIndex >= btns.Count)
        {
            Debug.LogError($"Invalid index parsed from GameObject's name: {name}");
            return;
        }

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = selectedIndex;
            firstGuesspuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = selectedIndex;
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
            countGuesses++;
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }

    IEnumerator CheckIfThePuzzlesMatch()
    {
        if (firstGuesspuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(0.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            CheckIfTheGameIsFinish();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }
        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinish()
    {
        countCorrectGuesses++;
        if (countCorrectGuesses == gameGuesses)
        {
            if (remainingTime > 0)
            {
                successPanel.SetActive(true);
                Debug.Log("You Won!");
                Debug.Log("It Took You " + countGuesses + " guesses to finish the game!");
            }
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverPanel.SetActive(true);
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
}
