using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController4 : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess, isChecking;
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
    public GameObject successPanel; // Panel untuk Sukses

    // Card count
    public int totalPairs = 8; // Total pasangan kartu yang dapat diubah di Inspector

    // Click limit variables
    public int maxClicks = 20; // Batas maksimal klik
    private int currentClicks = 0; // Klik saat ini
    public Text clickCounterText; // UI Text untuk jumlah klik

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
        gameGuesses = totalPairs;

        UpdateTimerUI();
        UpdateClickCounterUI();
        Audio.Instance.PlayMusic("Minigame");
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

    void UpdateClickCounterUI()
    {
        clickCounterText.text = "Clicks: " + currentClicks + "/" + maxClicks;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        // Hapus tombol jika jumlahnya melebihi kebutuhan
        if (objects.Length > totalPairs * 2)
        {
            for (int i = totalPairs * 2; i < objects.Length; i++)
            {
                Destroy(objects[i]);
            }
        }

        // Tambahkan tombol jika kurang
        for (int i = 0; i < totalPairs * 2 - objects.Length; i++)
        {
            GameObject newButton = Instantiate(objects[0], objects[0].transform.parent);
            newButton.name = (objects.Length + i).ToString();
        }

        btns.Clear();
        objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        foreach (GameObject obj in objects)
        {
            btns.Add(obj.GetComponent<Button>());
            obj.GetComponent<Button>().image.sprite = bgImage;
        }
    }

    void AddGamePuzzle()
    {
        gamePuzzles.Clear();
        for (int i = 0; i < totalPairs; i++)
        {
            gamePuzzles.Add(puzzles[i]);
            gamePuzzles.Add(puzzles[i]); // Tambahkan duplikat untuk pasangan
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
        if (isChecking) return; // Blokir input saat sedang mengecek kartu

        int buttonIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        // Pastikan kartu hanya bisa diklik jika masih belum dibuka
        if (!btns[buttonIndex].interactable || btns[buttonIndex].image.sprite != bgImage) return;

        currentClicks++;
        UpdateClickCounterUI();

        if (currentClicks > maxClicks)
        {
            GameOver();
            return;
        }

        btns[buttonIndex].image.sprite = gamePuzzles[buttonIndex];

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = buttonIndex;
            firstGuesspuzzle = gamePuzzles[firstGuessIndex].name;
        }
        else
        {
            secondGuess = true;
            secondGuessIndex = buttonIndex;
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            countGuesses++;
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }

    IEnumerator CheckIfThePuzzlesMatch()
    {
        isChecking = true; // Blokir input selama pengecekan
        yield return new WaitForSeconds(1f);

        if (firstGuesspuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinish();
        }
        else
        {
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }

        firstGuess = secondGuess = false;
        isChecking = false; // Izinkan input setelah pengecekan selesai
    }

    void CheckIfTheGameIsFinish()
    {
        countCorrectGuesses++;
        if (countCorrectGuesses == gameGuesses)
        {
            if (remainingTime > 0)
            {
                Debug.Log("You Won!");
                successPanel.SetActive(true); // Menampilkan panel sukses
                Audio.Instance.PlaySFX("Win");
            }
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverPanel.SetActive(true);
        Audio.Instance.PlaySFX("Lose");
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
