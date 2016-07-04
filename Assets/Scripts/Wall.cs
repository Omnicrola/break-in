using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{

    public AudioClip ballImpactSound;
    private Rigidbody2D _rigidBody;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            AudioPlayer.INSTANCE.Play(ballImpactSound);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
