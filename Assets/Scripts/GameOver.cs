using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{

    private PlayerMovement player;
    [SerializeField] private TextMeshProUGUI result_Text;
    private string text_to_display;

    void Start()
    {

        string winner = PlayerPrefs.GetString("Winner");
        string isAI = PlayerPrefs.GetString("isAI");

        if(winner == "Player 1"){
            text_to_display = "Player 1 has won";
        }
        else{
            if (isAI == "True"){
                text_to_display = "AI has won";
            }
            else{
                text_to_display = "Player 2 has won";
            }
        }
        result_Text.text = text_to_display;
    }


}
