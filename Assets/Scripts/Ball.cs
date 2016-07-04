using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public int initialVelocity = 400;

    private Rigidbody2D _rigidbody2D;
    private bool _isInMotion = false;

    // Use this for initialization
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        if (!_isInMotion)
        {
            _isInMotion = true;
            var velX = Random.Range(300, 500);
            var velY = Random.Range(300, 500);
            _rigidbody2D.AddForce(new Vector2(velX, velY));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
