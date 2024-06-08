using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    private AudioSource audioSource;

    void Awake()
    {
        if(backgroundMusic == null){
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
            audioSource = GetComponent<AudioSource>();
        }else{
            Destroy(gameObject);
        }
    }

    public static BackgroundMusic GetInstance()
    {
        return backgroundMusic;
    }

    public void SetVolume(float volume)
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        audioSource.volume = volume;
    }


}
