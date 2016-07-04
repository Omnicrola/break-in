using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public int initialVelocity = 400;

    // Use this for initialization
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(initialVelocity, initialVelocity));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
