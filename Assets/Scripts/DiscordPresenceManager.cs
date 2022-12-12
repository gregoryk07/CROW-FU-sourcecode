using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiscordPresence;
using UnityEngine.SceneManagement;

public class DiscordPresenceManager : MonoBehaviour
{
    public static DiscordPresenceManager instance;
    public string currentDiscordDetail, currentDiscordState;
    public string LargeImageKey = "";
    Scene scene;

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
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();

        if(scene.buildIndex == 0)
        {
            currentDiscordState = "Loading...";
        }
        if(scene.buildIndex == 1)
        {
            currentDiscordState = "In Menu";
        }
        if(scene.buildIndex > 1)
        {
            currentDiscordState = "In Game";
        }
        if (Debug.isDebugBuild)
        {
            currentDiscordDetail = "Testing";
        }
        else
        {
            currentDiscordDetail = "Playing";
        }

        PresenceManager.UpdatePresence(currentDiscordDetail, currentDiscordState, -1, -1, LargeImageKey, null, null, null, null, -1, -1, null, null, null);
    }
}
