using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public SpawnManagerAnimals spawnManager;   // Reference to your spawn script
    public Transform[] spawnPoints;            // Where animals can spawn

    
    public TextMeshProUGUI rescuedText;
    public TextMeshProUGUI deadText;
    public GameObject gameOverPanel;
    public GameObject gameOverWinPanel;
    public GameObject titleSreen;
    public Button restartButton;

    private int totalToRescue;
    private int maxDeaths = 3;

    private int rescuedCount = 0;
    private int deadCount = 0;

    private bool gameActive = false;

    // --- Call these from your menu buttons ---
    public void StartEasy()   { StartGame(5); }
    public void StartMedium() { StartGame(10); }
    public void StartHard()   { StartGame(15); }

    private void Start()
{
    // Freeze everything
    Time.timeScale = 0f;
}

    private void StartGame(int totalAnimals)
    {
        totalToRescue = totalAnimals;
        rescuedCount = 0;
        deadCount = 0;
        gameActive = true;

        UpdateUI();

        titleSreen.gameObject.SetActive(false);
        Time.timeScale = 1f;

        // Spawn all animals at the start
        spawnManager.SpawnAnimals(spawnPoints, 5f);
    }

    private void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AnimalRescued()
    {
        if (!gameActive) return;

        rescuedCount++;
        UpdateUI();
        CheckGameOverWin();
    }

    public void AnimalDead()
    {
        if (!gameActive) return;

        deadCount++;
        UpdateUI();
        CheckGameOver();
    }

    private void UpdateUI()
    {
        rescuedText.text = $"Rescued: {rescuedCount}/{totalToRescue}";
        deadText.text = $"Dead: {deadCount}/{maxDeaths}";
    }

    private void CheckGameOver()
    {
        if (deadCount >= maxDeaths)
        {
            GameOver("Too many animals died! Game Over!");
        }
    }

    private void CheckGameOverWin()
    {
        if (rescuedCount >= totalToRescue)
        {
            GameOverWin("All animals rescued! You win!");
        }
    }

    private void GameOverWin(string message)
    {
        gameActive = false;
        gameOverWinPanel.SetActive(true);
        Debug.Log(message);
        Time.timeScale = 0f; // freeze the game
    }

    private void GameOver(string message)
    {
        gameActive = false;
        gameOverPanel.SetActive(true);
        Debug.Log(message);
        Time.timeScale = 0f; // freeze the game
    }
}
