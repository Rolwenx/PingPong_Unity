using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI result_Text;
    private string textToDisplay;

    void Start()
    {

        DisplayResult();
    }


    private void DisplayResult()
    {
        string winner = PlayerPrefs.GetString("Winner");
        string isAI = PlayerPrefs.GetString("isAI");

        if (winner == "Player 1")
        {
            textToDisplay = "Player 1 has won";
        }
        else
        {
            if (isAI == "True")
            {
                textToDisplay = "AI has won";
            }
            else
            {
                textToDisplay = "Player 2 has won";
            }
        }

        result_Text.text = textToDisplay;
    }

    public void Replay()
        {
            string isAI = PlayerPrefs.GetString("isAI");


            if (isAI == "True")
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }

}
