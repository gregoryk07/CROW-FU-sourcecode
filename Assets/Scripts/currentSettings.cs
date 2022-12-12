using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentSettings : MonoBehaviour
{
    public static currentSettings instance;
    public bool fullScreen;
    public int resolutionInt;
    public int qualityInt;
    public float MasterVolume;
    public float MusicVolume;
    public float SorroundVolume;
    public bool PostProcessing;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
        if(SaveSystem.CheckSettings() == false)
        {
            CreateSettingsFile();
        }
        SettingsData data = SaveSystem.LoadSettings();
        fullScreen = data.fullscreen;
        resolutionInt = data.resolutionInt;
        qualityInt = data.qualityInt;
        MasterVolume = data.Master;
        MusicVolume = data.Music;
        SorroundVolume = data.Sorround;
        PostProcessing = data.PostProcessing;
        SaveSystem.SaveSettings(this);

    }
    public void CreateSettingsFile()
    {
        fullScreen = true;
        resolutionInt = 0;
        qualityInt = 0;
        MasterVolume = -30;
        MusicVolume = -30;
        SorroundVolume = -30;
        PostProcessing = true;
        SaveSystem.SaveSettings(this);
    }
}
