using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenResolution : MonoBehaviour
{
    void Start()
    {
        if (Screen.fullScreen)
        {
            // Set the resolution to the maximum available
            Screen.SetResolution(Screen.resolutions[Screen.resolutions.Length - 1].width, 
                                 Screen.resolutions[Screen.resolutions.Length - 1].height, 
                                 true); 
        }
    }
}

