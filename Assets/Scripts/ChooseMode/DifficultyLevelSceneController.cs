using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyLevelSceneController : MonoBehaviour
{
    public void SetDifficultyLevel(string difficulty)
    {
        PlayerPrefs.SetString("Difficulty", difficulty);
    }
}
