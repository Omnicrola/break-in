using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    // Use this for initialization
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(new Vector2(600, 600));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
