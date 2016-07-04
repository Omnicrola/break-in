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
    public Text scoreDisplay;

    private Transform bricksHolder;
    private int score = 0;


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
    }

    public void BuildLevel()
    {
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
        scoreDisplay.text = "Score: " + score;
    }
}
