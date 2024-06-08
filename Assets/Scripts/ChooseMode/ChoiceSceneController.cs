using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceSceneController : MonoBehaviour
{
    public void SetGameMode(int mode)
    {
        PlayerPrefs.SetInt("GameMode", mode);
    }
}
