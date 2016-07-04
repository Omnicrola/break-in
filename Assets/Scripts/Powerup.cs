using UnityEngine;
using System.Collections;

public abstract class Powerup : MonoBehaviour
{

    protected float fallRate = 1.0f;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.activeSelf && collider.tag == "player")
        {
            AwardPowerup();
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y + (fallRate * Time.deltaTime * -1);
        transform.position = new Vector3(x, y);
    }

    protected abstract void AwardPowerup();
}
