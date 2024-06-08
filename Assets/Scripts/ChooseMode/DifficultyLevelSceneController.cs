using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyLevelSceneController : MonoBehaviour
{
    public void SetDifficultyLevel(string difficulty)
    {
        PlayerPrefs.SetString("Difficulty", difficulty);
        LoadGameplayScene();
    }

    private void LoadGameplayScene()
    {
        int gameMode = PlayerPrefs.GetInt("GameMode", 1);
        string difficulty = PlayerPrefs.GetString("Difficulty", "Normal"); 

        string sceneName = "";

        // 1 player
        if (gameMode == 1)
        {
            sceneName = "PingPong1P_" + difficulty;
        }
        // 2 Player
        else
        {
            sceneName = "PingPong2P_" + difficulty;
        }


        SceneManager.LoadScene(sceneName);
    }
}
