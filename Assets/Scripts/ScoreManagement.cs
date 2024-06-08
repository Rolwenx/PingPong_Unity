using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManagement : MonoBehaviour
{
    [SerializeField] private int scoreToReach;
    private float player1_score = 0;
    private float player2_score = 0;

    public TextMeshProUGUI player1_scoreText;
    public TextMeshProUGUI player2_scoreText;

    
    public void Player1Scores()
    {
        player1_score++;
        player1_scoreText.text = player1_score.ToString();
        checkScore();
    }

    public void Player2Scores()
    {
        player2_score++;
        player2_scoreText.text = player2_score.ToString();
        checkScore();
    }

    public void checkScore()
    {
        if (player1_score == scoreToReach)
        {
            PlayerPrefs.SetString("Winner", "Player 1");
            SceneManager.LoadScene(3);
        }
        else if (player2_score == scoreToReach)
        {
            PlayerPrefs.SetString("Winner", "Player 2");
            SceneManager.LoadScene(3);
        }
    }
}
