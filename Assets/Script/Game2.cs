using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Untuk scene management

public class MiniGame2 : MonoBehaviour
{
    [SerializeField] private Sprite bgImage;
    [SerializeField] private GameObject gameOverPopup; // Panel Popup Game Over
    [SerializeField] private GameObject successPopup; // Panel Popup Success
    [SerializeField] private Text remainingClicksText; // UI untuk sisa klik

    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess, isChecking;
    private int countClicks;
    private int countCorrectGuesses;
    private int gameGuesses;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;

    [SerializeField] private int maxClicks = 10; // Batas maksimal klik

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

        UpdateRemainingClicks();
        gameOverPopup.SetActive(false);
        successPopup.SetActive(false);
        isChecking = false; // Pastikan input terkunci saat pengecekan
        Audio.Instance.PlayMusic("Minigame");
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
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
    if (isChecking || countClicks >= maxClicks) return;

    int buttonIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

    // Pastikan tombol hanya bisa diklik jika belum dibuka
    if (!btns[buttonIndex].interactable || btns[buttonIndex].image.sprite != bgImage) return;

    // Tambahkan hitungan klik setiap kartu diklik
    countClicks++;
    UpdateRemainingClicks();

    // Jika batas klik sudah tercapai dan belum selesai, Game Over
    if (countClicks >= maxClicks && countCorrectGuesses < gameGuesses)
    {
        GameOver();
        return;
    }

    btns[buttonIndex].image.sprite = gamePuzzles[buttonIndex];

    if (!firstGuess)
    {
        firstGuess = true;
        firstGuessIndex = buttonIndex;
        firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
    }
    else if (!secondGuess)
    {
        secondGuess = true;
        secondGuessIndex = buttonIndex;
        secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

        StartCoroutine(CheckIfThePuzzlesMatch());
    }
}


    IEnumerator CheckIfThePuzzlesMatch()
    {
        isChecking = true;
        yield return new WaitForSeconds(1f);

        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            countCorrectGuesses++;
            CheckIfTheGameIsFinish();
        }
        else
        {
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }

        firstGuess = secondGuess = false;
        isChecking = false;
    }

    private void GameOver()
    {
        foreach (Button btn in btns)
        {
            btn.interactable = false; // Nonaktifkan semua tombol
        }
        gameOverPopup.SetActive(true); // Tampilkan popup Game Over
        Audio.Instance.PlaySFX("Lose");
    }

    private void Success()
    {
        foreach (Button btn in btns)
        {
            btn.interactable = false; // Nonaktifkan semua tombol
        }
        successPopup.SetActive(true); // Tampilkan popup Success
        Audio.Instance.PlaySFX("Win");
    }

    void CheckIfTheGameIsFinish()
    {
        if (countCorrectGuesses == gameGuesses)
        {
            Success();
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

    void UpdateRemainingClicks()
    {
        int remainingClicks = maxClicks - countClicks;
        Debug.Log("Clicks: " + remainingClicks + "/" + maxClicks);
        remainingClicksText.text = "Clicks: " + remainingClicks + "/" + maxClicks;
    }
}
