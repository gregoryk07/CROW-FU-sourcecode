using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSaveSet : MonoBehaviour
{

    public bool fullScreen, PostProcessing;
    public int resolutionInt, qualityInt;
    public float MasterVolume, MusicVolume, SorroundVolume;
    [Header("To assign in inspector")]
    public Slider master;
    public Slider music;
    public Slider sorround;
    public Toggle fullscreen_T;
    public TMP_Dropdown resolution, quality;
    public Toggle PostProcessing_T;


    // Start is called before the first frame update
    void Start()
    {
        PostProcessing = currentSettings.instance.PostProcessing;
        fullScreen = currentSettings.instance.fullScreen;
        resolutionInt = currentSettings.instance.resolutionInt;
        qualityInt = currentSettings.instance.qualityInt;
        MasterVolume = currentSettings.instance.MasterVolume;
        MusicVolume = currentSettings.instance.MusicVolume;
        SorroundVolume = currentSettings.instance.SorroundVolume;
        PostProcessing_T.isOn = PostProcessing;
        master.value = MasterVolume;
        music.value = MusicVolume;
        sorround.value = SorroundVolume;
        fullscreen_T.isOn = fullScreen;
        resolution.value = resolutionInt;
        quality.value = qualityInt;
    }

    // Update is called once per frame
    public void SaveSettings()
    {
        PostProcessing = PostProcessing_T.isOn;
        MasterVolume = master.value;
        MusicVolume = music.value;
        SorroundVolume = sorround.value;
        fullScreen = fullscreen_T.isOn;
        resolutionInt = resolution.value;
        qualityInt = quality.value;
        currentSettings.instance.MasterVolume = MasterVolume;
        currentSettings.instance.MusicVolume = MusicVolume;
        currentSettings.instance.SorroundVolume = SorroundVolume;
        currentSettings.instance.fullScreen = fullScreen;
        currentSettings.instance.resolutionInt = resolutionInt;
        currentSettings.instance.qualityInt = qualityInt;
        currentSettings.instance.PostProcessing = PostProcessing;
        SaveSystem.SaveSettings(currentSettings.instance);
    }
    public void SaveFullscreen(bool x)
    {
        fullScreen = fullscreen_T.isOn;
        currentSettings.instance.fullScreen = fullScreen;
        SaveSystem.SaveSettings(currentSettings.instance);
    }
    public void SavePostProcessing(bool x)
    {
        PostProcessing = PostProcessing_T.isOn;
        currentSettings.instance.PostProcessing = PostProcessing;
        SaveSystem.SaveSettings(currentSettings.instance);
    }
    public void SaveRes(int x)
    {
        resolutionInt = resolution.value;
        currentSettings.instance.resolutionInt = resolutionInt;
        SaveSystem.SaveSettings(currentSettings.instance);
    }
    public void SaveQua(int x)
    {
        qualityInt = quality.value;
        currentSettings.instance.qualityInt = qualityInt;
        SaveSystem.SaveSettings(currentSettings.instance);
    }
    public void SaveMaster(float x)
    {
        MasterVolume = master.value;
        currentSettings.instance.MasterVolume = MasterVolume;
        SaveSystem.SaveSettings(currentSettings.instance);
    }
    public void SaveMusic(float x)
    {
        MusicVolume = music.value;
        currentSettings.instance.MusicVolume = MusicVolume;
        SaveSystem.SaveSettings(currentSettings.instance);
    }
    public void SaveSorround(float x)
    {
        SorroundVolume = sorround.value;
        currentSettings.instance.SorroundVolume = SorroundVolume;
        SaveSystem.SaveSettings(currentSettings.instance);
    }
    
}
