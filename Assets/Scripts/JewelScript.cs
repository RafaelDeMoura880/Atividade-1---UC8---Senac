using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class JewelScript : MonoBehaviourPun
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PhotonNetwork.IsMasterClient && collision.CompareTag("Player"))
        {
            PlayerScript player = collision.GetComponent<PlayerScript>();
            player.Score();
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
