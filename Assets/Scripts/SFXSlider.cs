using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    [SerializeField] Slider sfx_slider;
    [SerializeField] AudioSource[] sfxAudioSources; // Array of SFX audio sources
    private float storedVolume = 1.0f; // Temporary variable to store SFX volume

     public float getVolume(){
        return storedVolume;
    }


    void Start()
    {
        LoadSFX();
        sfx_slider.onValueChanged.AddListener(delegate { ChangeVolumeSFX(); });
    }

    public void ChangeVolumeSFX()
    {
        storedVolume = sfx_slider.value; // Store the new volume value
        ApplyVolume(); // Apply the volume immediately (even if the slider is disabled)
        SaveSFX();
    }

    private void ApplyVolume()
    {
        // We terate through all SFX audio sources and set their volumes
        foreach (AudioSource audioSource in sfxAudioSources)
        {
            audioSource.volume = storedVolume; 
        }
    }

    private void LoadSFX()
    {
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfx_slider.value = PlayerPrefs.GetFloat("SFXVolume");
            storedVolume = sfx_slider.value; // Store the initial volume
            ApplyVolume(); // Apply the initial volume
        }
    }

    private void SaveSFX()
    {
        PlayerPrefs.SetFloat("SFXVolume", storedVolume);
    }

    // Method to set the volume externally (e.g., when the game is paused)
    public void SetVolume(float volume)
    {
        storedVolume = volume; 
        ApplyVolume(); 
    }
}
