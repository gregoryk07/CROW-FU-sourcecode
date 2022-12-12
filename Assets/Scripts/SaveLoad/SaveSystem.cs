using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SavePlayer(statsManager player, int saveNum)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/saves/save" + saveNum + ".sav";
        string directory = Application.persistentDataPath + "/saves/";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Saved on slot " + saveNum + "!");
    }
    public static PlayerData LoadPlayer(int saveNum)
    {
        string path = Application.persistentDataPath + "/saves/save"+saveNum+".sav";
        string directory = Application.persistentDataPath + "/saves/";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            Debug.Log("Loaded slot " + saveNum + "!");
            return data;
        }
        else
        {
            Debug.LogError("Save Game File not found :/");
            return null;
        }
    }
    public static void DeletePlayer(int saveNum)
    {
        
        string path = Application.persistentDataPath + "/saves/save" + saveNum + ".sav";
        string directory = Application.persistentDataPath + "/saves/";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.LogError("Save Game File not found :/");
        }
            Debug.Log("Deleted slot " + saveNum + "!");
    }
    public static bool CheckSave(int saveNum)
    {
        string path = Application.persistentDataPath + "/saves/save"+saveNum+".sav";
        string directory = Application.persistentDataPath + "/saves/";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public static void SaveSettings(currentSettings player)
    {
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/settings/settings.conf";
            string directory = Application.persistentDataPath + "/settings/";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            FileStream stream = new FileStream(path, FileMode.Create);

            SettingsData data = new SettingsData(player);

            formatter.Serialize(stream, data);
            stream.Close();
            Debug.Log("Saved settings!");
        }
    }
    public static SettingsData LoadSettings()
    {
        string path = Application.persistentDataPath + "/settings/settings.conf";
        string directory = Application.persistentDataPath + "/settings/";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SettingsData data = formatter.Deserialize(stream) as SettingsData;
            stream.Close();
            Debug.Log("Loaded settings!");
            return data;
        }
        else
        {
            Debug.LogError("Settings Save File not found :/");
            return null;
        }
    }
    public static bool CheckSettings()
    {
        string path = Application.persistentDataPath + "/settings/settings.conf";
        string directory = Application.persistentDataPath + "/settings/";
        if (!Directory.Exists(directory))
        {
            Debug.Log("Settings file directory does not exist, creating...");
            Directory.CreateDirectory(directory);
        }
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
