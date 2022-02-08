using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerScript : MonoBehaviourPun, IPunObservable
{
    public float speed;
    public float speedTurn = 3;
    public int score;

    bool isMoving;
    float turnDirection;

    Rigidbody2D playerRb;

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

        isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            turnDirection = 1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            turnDirection = -1f;
        else
            turnDirection = 0f;
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
            return;

        if (isMoving)
            playerRb.AddForce(this.transform.up * this.speed);
        if (turnDirection != 0f)
            playerRb.AddTorque(turnDirection * this.speedTurn);
    }

    [PunRPC]
    void RPCScore()
    {
        score++;
    }

    public void Score()
    {
        photonView.RPC("RPCScore", RpcTarget.All);
    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
            stream.SendNext(score);
        else
            score = (int)stream.ReceiveNext();
    }
}
