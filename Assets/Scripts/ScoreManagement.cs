using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManagement : MonoBehaviour
{
    private float player1_score = 0;
    private float player2_score = 0;

    public TextMeshProUGUI player1_scoreText;
    public TextMeshProUGUI player2_scoreText;

    public void Player1Scores(){
        player1_score++;
        player1_scoreText.text = player1_score.ToString();
    }

    public void Player2Scores(){
        player2_score++;
        player2_scoreText.text = player2_score.ToString();
    }

}
