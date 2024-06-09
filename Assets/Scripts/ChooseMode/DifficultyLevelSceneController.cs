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

        string sceneName = "";

        // 1 player
        if (gameMode == 1)
        {
            sceneName = "PingPong1P";
        }
        else if(gameMode == 2)
        {
            sceneName = "PingPong2P";
        }
        else{
            sceneName = "PingPongAI";
        }


        SceneManager.LoadScene(sceneName);
    }
}
