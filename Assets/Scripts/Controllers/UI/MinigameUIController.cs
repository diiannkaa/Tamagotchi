using TMPro;
using UnityEngine;

public class MinigameUIController : MonoBehaviour
{
    public static MinigameUIController instance;
    public GameObject minigamePrefab, minigame;
    public GameObject[] minigamePrefabs; 
    public MinigameEndPanelController minigameEndUI;
    public MinigamePetController minigamePetController;
    public TextMeshProUGUI scoreText, timerText;
    private int score;
    private float timeRemaining;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one MinigameUIController in the Scene");
    }

    private void OnEnable()
    {
        minigamePetController.enabled = true;

        minigamePrefab = GameData.SelectedMinigamePrefab;
        if (minigamePrefab == null && minigamePrefabs.Length > 0)
        {
            minigamePrefab = minigamePrefabs[0];
        }
        if (minigamePrefab != null)
        {
            minigame = Instantiate(minigamePrefab);
            minigame.GetComponent<BaseMinigameController>().Initialize(minigamePetController.transform);
        }
        if (minigamePrefab == minigamePrefabs[0])
        {
            BackgroundController.instance.SetMinigameBackgroundActive(true);
            BackgroundController.instance.SetMinigame2BackgroundActive(false);
        }
        else if (minigamePrefab == minigamePrefabs[1])
        {
            BackgroundController.instance.SetMinigameBackgroundActive(false);
            BackgroundController.instance.SetMinigame2BackgroundActive(true);
        }
        else
        {
            Debug.LogWarning("Minigame prefab is not set in GameData");
        }
    }

    public virtual void ChangeScore(int amount)
    {
        score += amount;
        UpdateScore(score);
    }

    public void UpdateScore(int score)
    {
        this.score = score;
        if (score >= 3) FinishMinigame(score, timeRemaining);
        scoreText.text = "Score: " + score;
    }

    public void UpdateTimer(float timer)
    {
        timeRemaining = timer;
        timerText.text = string.Format("Time left: {0}", timer);
    }

    private void ResetScore()
    {
        score = 0;
        UpdateScore(score);
    }

    public void FinishMinigame(int score, float timeRemaining)
    {
        ResetScore();
        Destroy(minigame);
        minigameEndUI.gameObject.SetActive(true);
        Camera.main.orthographicSize = 10;
        Camera.main.transform.position = new Vector3(0, 0, -10);
        minigameEndUI.Initialize(score, timeRemaining, timeRemaining > 0);
        minigamePetController.GetComponent<NeedsController>().ChangeHappiness(20);
    }

    public void LoseMinigame()
    {
        ResetScore();
        Destroy(minigame);
        minigamePetController.GetComponent<NeedsController>().ChangeHappiness(10);
        minigameEndUI.gameObject.SetActive(true);
        Camera.main.orthographicSize = 10;
        Camera.main.transform.position = new Vector3(0, 0, -10);
        minigameEndUI.Initialize(score, timeRemaining, false);
    }

    public void LoseMinigameToEnemy()
    {
        ResetScore();
        Destroy(minigame);
        minigameEndUI.gameObject.SetActive(true);
        Camera.main.orthographicSize = 10;
        Camera.main.transform.position = new Vector3(0, 0, -10);
        minigameEndUI.Initialize(score, timeRemaining, false);
    }
}
