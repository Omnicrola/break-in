using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour
{
    public LevelManager levelManager;
    public Vector2 respawnPosition;

    private bool isNotRespawning = true;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isNotRespawning && collider.tag == "ball")
        {
            isNotRespawning = false;
            collider.gameObject.SetActive(false);
            Invoke("RespawnBall", 2f);

            levelManager.RemoveBall(1);
        }
    }

    public void RespawnBall()
    {
        levelManager.RespawnBall(respawnPosition);
        isNotRespawning = true;
    }
}
