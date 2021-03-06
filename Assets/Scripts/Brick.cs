﻿using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

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
            DestroyBrick();
        }
    }

    private void DestroyBrick()
    {
        AudioPlayer.INSTANCE.Play(ballImpactSound);
        LevelManager.INSTANCE.AddScore(10);
        gameObject.SetActive(false);
        var powerupPrefab = PowerupTable.AwardPowerup();
        if (powerupPrefab != null)
        {
            var powerup = Instantiate(powerupPrefab) as GameObject;
            var ourPosition = gameObject.transform.position;
            powerup.transform.position = new Vector3(ourPosition.x, ourPosition.y, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
