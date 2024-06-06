using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}

