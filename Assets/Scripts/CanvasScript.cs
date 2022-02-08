using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Text scoreText;

    private void Update()
    {
        PlayerScript[] players = GameObject.FindObjectsOfType<PlayerScript>();
        string txtScore = "";
        foreach (PlayerScript p in players)
            txtScore += p.score + "; ";
        scoreText.text = txtScore;
    }
}
