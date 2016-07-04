using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float yPosition = 10;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

        rigidBody.MovePosition(new Vector2(x, yPosition));
    }
}
