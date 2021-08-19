using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI statsText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI easyText;
    public TextMeshProUGUI mediumText;
    public TextMeshProUGUI hardText;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject Vulture;
    public GameObject Point;
    public Button restartButton;
    public AudioClip crashSound;
    public AudioClip pointSound;

    private AudioSource gameAudio;

    static public int playerHealth = 3;
    public int playerScore = 0;
    public bool gameOver = false;
    public string difficulty;
    private float spawnPositionZ = 12.5f;
    private float spawnRangeX = 4.0f;
    private float spawnRate = 1.5f;

    void Start() {
        easyText.text = "Highscore: " + PlayerPrefs.GetInt("EasyHighscore", 0).ToString();
        mediumText.text = "Highscore: " + PlayerPrefs.GetInt("MediumHighscore", 0).ToString();
        hardText.text = "Highscore: " + PlayerPrefs.GetInt("HardHighscore", 0).ToString();
        gameAudio = GetComponent<AudioSource>();
    }

    // The Function Below is used when the Player clicks on a Difficulty Button
    public void GameStart() {
        titleScreen.gameObject.SetActive(false);
        statsText.gameObject.SetActive(true);
        InvokeRepeating("SpawnPoint", 2.0f, Random.Range(1.0f, 5.0f));
        InvokeRepeating("SpawnVulture", 1.5f, spawnRate);
        if (difficulty == "Medium") {
            InvokeRepeating("SpawnVulture", 1.5f, (spawnRate / 2));
        }
        if (difficulty == "Hard") {
            InvokeRepeating("SpawnVulture", 1.5f, (spawnRate / 3));
        }
    }

    // Functions Below are used when the Player gets a Game Over
    void GameOver() {
        gameOver = true;
        if (difficulty == "Easy" && (playerScore > PlayerPrefs.GetInt("EasyHighscore", 0))) {
            PlayerPrefs.SetInt("EasyHighscore", playerScore);
            easyText.text = playerScore.ToString();
        }
        if (difficulty == "Medium" && (playerScore > PlayerPrefs.GetInt("MediumHighscore", 0))) {
            PlayerPrefs.SetInt("MediumHighscore", playerScore);
            mediumText.text = playerScore.ToString();
        }
        if (difficulty == "Hard" && (playerScore > PlayerPrefs.GetInt("HardHighscore", 0))) {
            PlayerPrefs.SetInt("HardHighscore", playerScore);
            hardText.text = playerScore.ToString();
        }
        gameOverText.text = "Game Over\nScore: " + playerScore;
        gameOverScreen.gameObject.SetActive(true);
        statsText.gameObject.SetActive(false);
    }

    private void ResetVariables() {
        playerHealth = 3;
        playerScore = 0;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResetVariables();
    }

    // Functions Below are used for Collisions with Enemies and Points
    public void CollectPoint() {
        playerScore++;
        statsText.text = "Score: " + playerScore + "\nLives: " + playerHealth;
        gameAudio.PlayOneShot(pointSound, 0.5f);
    }

    public void HitHazard() {
        playerHealth--;
        statsText.text = "Score: " + playerScore + "\nLives: " + playerHealth;
        gameAudio.PlayOneShot(crashSound, 0.5f);
        if (playerHealth < 1) {
            GameOver();
        }
    }

    // Functions Below are used for Spawning Enemies and Points
    void SpawnVulture() {
        if (!gameOver) {
            Instantiate(Vulture, SpawnPosition(), Vulture.transform.rotation);
        }
    }

    void SpawnPoint() {
        if (!gameOver) {
            Instantiate(Point, SpawnPosition(), Point.transform.rotation);
        }
    }

    private Vector3 SpawnPosition() {
        return new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPositionZ);
    }
}
