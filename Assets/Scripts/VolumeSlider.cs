using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// We are now able to use UI object
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;


    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume",1);
            Load();
        }
        else{
            Load();
        }
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    public void ChangeVolume()
    {
        float volume = volumeSlider.value;
        BackgroundMusic bgMusic = BackgroundMusic.GetInstance();
        if (bgMusic != null)
        {
            bgMusic.SetVolume(volume);
        }
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        BackgroundMusic bgMusic = BackgroundMusic.GetInstance();
        if (bgMusic != null)
        {
            bgMusic.SetVolume(volumeSlider.value);
        }
    }


    private void Save(){
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
