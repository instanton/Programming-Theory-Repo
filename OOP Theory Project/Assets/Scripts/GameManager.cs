using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject yellowBallPrefab;
    public GameObject redBallPrefab;
    public TextMeshProUGUI livesRemainingText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI gameOverText;


    private int score = 0;
    private int livesRemaining = 2;
    private Vector3 spawnPos;

    private float yellowBallStartDelay = 5;
    private float yellowBallRepeatRate = 5;
    private float goodBallStartDelay = 2;
    private float goodBallRepeatRate = 3;
    
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnYellowBall", yellowBallStartDelay, yellowBallRepeatRate);
        InvokeRepeating("SpawnGoodBall", goodBallStartDelay, goodBallRepeatRate);

        if (MainManager.Instance != null)
        {
            nameText.text = "Player: " + MainManager.Instance.playerName;
        }

        // ABSTRACTION
        UpdateScore(0);
        UpdateHighScore();
        UpdateLivesRemaining(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void SpawnYellowBall()
    {
        spawnPos = new Vector3(Random.Range(-10.0f, 10.0f), 4, -6);
        Instantiate(yellowBallPrefab, spawnPos, yellowBallPrefab.transform.rotation);
    }

    void SpawnGoodBall()
    {
        spawnPos = new Vector3(Random.Range(-10.0f, 10.0f), 4, -6);
        Instantiate(redBallPrefab, spawnPos, redBallPrefab.transform.rotation);
    }

    public void GameOver()
    {
        gameOver = true;

        // stop spawning and cleanup
        CancelInvoke();

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }

        Debug.Log("Current High Score: " + MainManager.Instance.highScore);
        if (score > MainManager.Instance.highScore)
        {
            Debug.Log("UPDATING HIGH SCORE");
            
            MainManager.Instance.highScore = score;
            MainManager.Instance.highScorePlayerName = MainManager.Instance.playerName;

            //Debug.Log("New High Score: " + score);

            UpdateHighScore();
        }

        gameOverText.gameObject.SetActive(true);
    }

    public void UpdateScore(int value)
    {
        score += value;

        scoreText.text = "Score : " + score;
    }

    public void UpdateLivesRemaining(int value)
    {
        livesRemaining -= value;

        //update text
        livesRemainingText.text = "Lives Remaining: " + livesRemaining;

        if (livesRemaining == 0)
        {
            GameOver();
        }
    }

    public void UpdateHighScore()
    {
        if (MainManager.Instance != null)
        {
            Debug.Log("PRINTING HIGH SCORE");
            highScoreText.text = "High Score: " + MainManager.Instance.highScore + "\nName: " + MainManager.Instance.highScorePlayerName;
        }
    }
}
