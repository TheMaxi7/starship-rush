using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider effectsSlider;
    public Toggle fullscreenToggle;
    private float defaultVolume = 0;
    private int defaultQuality = 3;
    public AudioMixer audioMixer;
    public TMP_Dropdown qualityDropdown;
   
    
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
            LoadMusic();
        else
            SetMusic();


        if (PlayerPrefs.HasKey("SFXVolume"))
            LoadEffects();
        else
            SetEffects();


        if (PlayerPrefs.HasKey("isFullscreen"))
            LoadScreen();
        else
            SetFullscreen(true);


        if(PlayerPrefs.HasKey("qualityLevel"))
            LoadQuality();
        else
            SetQuality();
    }

    private void Update()
    {
       
 
    }


    public void SetMusic()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);

    }

    public void LoadMusic()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SetMusic();
    }

    public void SetEffects()
    {
        float volume = effectsSlider.value;
        audioMixer.SetFloat("SFXVolume",volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);

    }

    public void LoadEffects()
    {
        effectsSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetEffects();
    }


    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen == true)
            PlayerPrefs.SetInt("isFullscreen", 1);
        else
            PlayerPrefs.SetInt("isFullscreen", 0);
    }

    public void LoadScreen()
    {
        if (PlayerPrefs.GetInt("isFullscreen") == 1)
        {
            SetFullscreen(true);
            fullscreenToggle.isOn = true;
        }
        else
        {
            SetFullscreen(false);
            fullscreenToggle.isOn = false;
        }
            
    }
    
    public void SetQuality()
    {
        int qualityIndex = qualityDropdown.value;
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityLevel", qualityIndex);

    }

    public void LoadQuality()
    {
        qualityDropdown.value = PlayerPrefs.GetInt("qualityLevel");
        SetQuality();
    }
    public void ResetSettings()
    {

        qualityDropdown.value = defaultQuality;
        
        fullscreenToggle.isOn = true;
        Screen.fullScreen = true;
        
        musicSlider.value = defaultVolume;
        audioMixer.SetFloat("MusicVolume", defaultVolume);
        effectsSlider.value = defaultVolume;
        audioMixer.SetFloat("SFXVolume", defaultVolume);
    }
    
    
}
