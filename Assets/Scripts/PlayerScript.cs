using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerScript : MonoBehaviourPun
{
    public float speed;

    Rigidbody2D playerRb;
    float inputH;
    float inputV;

    public int score;

    SpriteRenderer playerColor;

    private void Awake()
    {
        score = 0;
        speed = 7;
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerColor = GetComponent<SpriteRenderer>();

        if (photonView.IsMine)
            playerColor.material.color = Color.green;
    }
}
