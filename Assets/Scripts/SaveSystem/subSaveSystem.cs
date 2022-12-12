using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class subSaveSystem : MonoBehaviour
{
    public int gameLevelInt = 2;
    public int saveInt;
    public bool fileExists = false;
    public string saveName, saveNum, saveDate;
    public float savePercentage;
    public TMP_Text saveNametext, saveNumtext, saveDatetext, savePercentagetext;
    public GameObject saveLabel;
    public TMP_InputField creationInputField;
    public GameObject saveCreate;
    PlayerData data;
    public GameObject deleteButton;

    // Update is called once per frame
    void Start()
    {

        fileExists = File.Exists(Application.persistentDataPath + "/saves/save" + saveInt + ".sav");
        string directory = Application.persistentDataPath + "/saves/";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        if (fileExists)
        {
            data = SaveSystem.LoadPlayer(saveInt);
            saveDate = data.playerDate;
            saveName = data.playerName;
            savePercentage = data.playerPercentage;
            //saveNametext.text = saveName;
            //saveNumtext.text = saveInt.ToString();
            //saveDatetext.text = saveDate;
            //savePercentagetext.text = savePercentage.ToString("");
            //saveLabel.SetActive(false);
            //deleteButton.SetActive(true);
        }
        else
        {
            //saveNametext.text = " ";
            //saveNumtext.text = " ";
            //saveDatetext.text = " ";
            //savePercentagetext.text = " ";
            //saveLabel.SetActive(true);
            //deleteButton.SetActive(false);
        }
    }
    public void SelectSave()
    {
        if (fileExists)
        {
            data = SaveSystem.LoadPlayer(saveInt);
            curSaveInfo.instance.saveName = data.playerName;
            curSaveInfo.instance.saveDate = data.playerDate;
            curSaveInfo.instance.saveHealth = data.health;
            curSaveInfo.instance.saveMaxHealth = data.maxHealth;
            curSaveInfo.instance.savePercentage = data.playerPercentage;
            curSaveInfo.instance.savePos = new Vector3(data.position[0], data.position[1], data.position[2]);
            curSaveInfo.instance.saveRot = new Vector3(0, data.rotation[1], data.rotation[2]);
            curSaveInfo.instance.saveLevel = data.level;
            curSaveInfo.instance.saveInt = saveInt;
            curSaveInfo.instance.jumpHeight = data.jumpHeight;
            curSaveInfo.instance.movementSpeed = data.playerSpeed;
            LevelLoader.instance.LoadLevel(gameLevelInt);
        }
        else
        {
            CreateSave();
        }
    }
    public void CreateSave()
    {
        SaveSystem.SavePlayer(statsManager.instance, saveInt);
        Start();
    }
    public void DeleteSave()
    {
        SaveSystem.DeletePlayer(saveInt);
        Start();
    }
}
