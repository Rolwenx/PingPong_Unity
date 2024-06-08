using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        int gameMode = PlayerPrefs.GetInt("GameMode", 1); // Default to 1 player mode if not set
        string difficulty = PlayerPrefs.GetString("Difficulty", "Easy"); // Default to Easy if not set

        string sceneName = "";

        // Choose scene name based on game mode and difficulty level
        if (gameMode == 1)
        {
            sceneName = "PingPong1P" + difficulty;
        }
        else
        {
            sceneName = "PingPong2P" + difficulty;
        }

        // Load the appropriate gameplay scene
        SceneManager.LoadScene(sceneName);
    }
}
