using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceSceneController : MonoBehaviour
{
    // 1 = 1P
    // 2 = 2P
    public void SetGameMode(int mode)
    {
        PlayerPrefs.SetInt("GameMode", mode);
        SceneManager.LoadScene(6);
    }

}
