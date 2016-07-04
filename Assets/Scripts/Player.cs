using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public AudioClip ballImpactSound;
    public Text debugText;

    private Rigidbody2D rigidBody;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = 0;
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        rigidBody.MovePosition(new Vector2(x, rigidBody.position.y));

#else
        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            x = Camera.main.ScreenToWorldPoint(touch.position).x;
            rigidBody.MovePosition(new Vector2(x, rigidBody.position.y));
        }
#endif
        debugText.text = "x:" + transform.position.x + " y:" + transform.position.y;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            AudioPlayer.INSTANCE.Play(ballImpactSound);
        }
    }


}
