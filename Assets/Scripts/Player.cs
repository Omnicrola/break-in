using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float yPosition = 10;
    public AudioClip ballImpactSound;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            AudioPlayer.INSTANCE.Play(ballImpactSound);
        }
    }


}
