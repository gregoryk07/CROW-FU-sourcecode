using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curSaveInfo : MonoBehaviour
{
    public static curSaveInfo instance;
    public int saveInt;
    public float savePercentage;
    public string saveName;
    public string saveDate;
    public Vector3 savePos;
    public Vector3 saveRot;
    public int saveHealth;
    public int saveMaxHealth;
    public float saveLevel;
    public float movementSpeed;
    public float jumpHeight;

    public void SaveGame()
    {
        statsManager.instance.MaxHealth = saveMaxHealth;
        statsManager.instance.Health = saveHealth;
        statsManager.instance.saveName = saveName;
        statsManager.instance.savePercentage = savePercentage;
        statsManager.instance.saveDate = System.DateTime.Now.ToString();
        statsManager.instance.pos = savePos;
        statsManager.instance.rot = saveRot;
        statsManager.instance.Level = saveLevel;
        statsManager.instance.jumpHeight = jumpHeight;
        statsManager.instance.movementSpeed = movementSpeed;
        SaveSystem.SavePlayer(statsManager.instance, saveInt);
    }




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
    }
}
