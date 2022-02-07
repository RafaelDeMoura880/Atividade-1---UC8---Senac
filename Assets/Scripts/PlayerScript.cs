using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerScript : MonoBehaviourPun
{
    public float speed;
    public float speedTurn = 3;

    Rigidbody2D playerRb;
    float inputYmove;
    float inputZturn;

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

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        inputZturn = Input.GetAxis("Horizontal");
        inputYmove = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
            return;

        playerRb.AddTorque(inputZturn * speedTurn, ForceMode2D.Force);
        playerRb.AddForce(new Vector2(0, inputYmove * speed), ForceMode2D.Force);
    }
}
