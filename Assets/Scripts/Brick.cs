using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{

    public AudioClip ballImpactSound;
    public Sprite[] colors;

    private Rigidbody2D _rigidBody;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = colors[Random.Range(0, colors.Length)];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            AudioPlayer.INSTANCE.Play(ballImpactSound);
            LevelManager.INSTANCE.AddScore(10);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
