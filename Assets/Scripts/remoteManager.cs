using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
using TMPro;

public class remoteManager : MonoBehaviour
{
    public string version;
    public string readMoreURL;
    public GameObject newestVersionPanel;
    public TMP_Text newsHeaderText;
    public TMP_Text newsText;
    public TMP_Text versionText;
    public TMP_Text newestVersionText;

    public struct userAttributes { }
    public struct appAttributes { }

    public string newsHeader = "no News Header";
    public string news = "no news :(";
    public string newestVersion;
    public bool isUpToDate = true;

    private void Awake()
    {
        version = Application.version;
        CheckForUpdate();
    }

    public void CheckForUpdate()
    {
        ConfigManager.FetchCompleted += GetNews;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    void GetNews(ConfigResponse response)
    {
        readMoreURL = ConfigManager.appConfig.GetString("readMoreURL");
        newsHeader = ConfigManager.appConfig.GetString("NewsHeader");
        news = ConfigManager.appConfig.GetString("NewsText");
        newestVersion = ConfigManager.appConfig.GetString("version");
        isUpToDate = Application.version == newestVersion;
    }

    // Update is called once per frame
    void Update()
    {
        newsHeaderText.text = newsHeader;
        newsText.text = news;
        versionText.text = "version: " + Application.version;
        if (isUpToDate)
        {
            newestVersionPanel.SetActive(false);
        }
        else
        {
            newestVersionPanel.SetActive(true);
            newestVersionText.text = "the newer version (" + newestVersion + ") is available, download it from itch.io";
        }

        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    private void OnDestroy()
    {
        ConfigManager.FetchCompleted -= GetNews;
    }
}
