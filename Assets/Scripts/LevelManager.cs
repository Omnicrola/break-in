using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager INSTANCE;

    public float startX = 0;
    public float startY = 0;
    public int columns = 4;
    public int rows = 4;

    public GameObject brickPrefab;
    public GameObject ballPrefab;

    public Text scoreDisplay;
    public Text ballDisplay;
    public GameObject gameOver;

    private Transform bricksHolder;
    private int score = 0;
    private int balls = 3;


    void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else if (INSTANCE != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        BuildLevel();
        ResetUi();
    }

    private void ResetUi()
    {
        UpdateScore();
        UpdateBallDisplay();
    }

    public void BuildLevel()
    {
        gameOver.SetActive(false);
        bricksHolder = new GameObject("Bricks").transform;
        var min = brickPrefab.GetComponent<SpriteRenderer>().sprite.bounds.min;
        var max = brickPrefab.GetComponent<SpriteRenderer>().sprite.bounds.max;
        float width = max.x - min.x;
        float height = max.y - min.y;

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                float xPosition = (x * width) + startX;
                float yPosition = (y * height) + startY;
                GameObject newBrick = Instantiate(brickPrefab, new Vector3(xPosition, yPosition, 0f), Quaternion.identity) as GameObject;
                newBrick.transform.SetParent(bricksHolder);
            }
        }
    }

    public void AddScore(int gain)
    {
        score += gain;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreDisplay.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void RespawnBall(Vector2 respawnPosition)
    {
        if (balls >= 0)
        {
            var ball = Instantiate(ballPrefab, respawnPosition, Quaternion.identity) as GameObject;
            ball.GetComponent<Rigidbody2D>().MovePosition(respawnPosition);
            ball.SetActive(true);
        }
    }

    public void AddBall(int gain)
    {
        balls += gain;
        UpdateBallDisplay();

    }

    public void RemoveBall(int loss)
    {
        balls -= loss;
        UpdateBallDisplay();
    }

    private void UpdateBallDisplay()
    {
        ballDisplay.text = "Balls: " + balls;
        if (balls <= 0)
        {
            GameOver();
        }
    }

}
