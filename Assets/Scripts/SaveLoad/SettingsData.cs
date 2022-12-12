using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SettingsData
{
    public int resolutionInt;
    public int qualityInt;
    public bool fullscreen;
    public float Master;
    public float Music;
    public float Sorround;
    public bool PostProcessing;

    public SettingsData(currentSettings player)
    {
        resolutionInt = player.resolutionInt;
        qualityInt = player.qualityInt;
        fullscreen = player.fullScreen;
        Master = player.MasterVolume;
        Music = player.MusicVolume;
        Sorround = player.SorroundVolume;
        PostProcessing = player.PostProcessing;
    }

}
