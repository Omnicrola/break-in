using System;
using UnityEngine;
using System.Collections;

public class WallConstraint : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public enum Edge
    {
        NORTH, SOUTH, EAST, WEST
    }

    public Edge edge = Edge.NORTH;
    public float offsetX = 0;
    public float offsetY = 0;
    public float width = 1.0f;
    public float height = 1.0f;

    private SpriteRenderer _spriteRenderer;

    // Use this for initialization
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        PinToSideOfScreen();
    }

    private void PinToSideOfScreen()
    {
        var start = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1));
        var end = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));
        float screenWidth = Mathf.Abs(start.x - end.x);
        float screenHeight = Mathf.Abs(start.y - end.y);

        float x = screenWidth / 2f;
        float y = screenHeight / 2f;
        float scaledWidth = width;
        float scaledHeight = height;

        switch (edge)
        {
            case Edge.NORTH:
                y = end.y + offsetY;
                scaledWidth = screenWidth;
                break;
            case Edge.SOUTH:
                y = start.y + offsetY;
                scaledWidth = screenWidth;
                break;
            case Edge.EAST:
                x = end.x + offsetX;
                scaledHeight = screenHeight;
                break;
            case Edge.WEST:
                x = start.x + offsetX;
                scaledHeight = screenHeight;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        _rigidbody2D.MovePosition(new Vector2(x, y));
        gameObject.transform.localScale = new Vector3(scaledWidth, scaledHeight);

    }


    // Update is called once per frame
    void Update()
    {
    }
}
