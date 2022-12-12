using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public float level;
    public int health;
    public int maxHealth;
    public float[] position;
    public float[] rotation;
    public string playerName;
    public string playerDate;
    public float playerPercentage;
    public float playerSpeed;
    public float jumpHeight;
    public bool xNegative;

    public PlayerData (statsManager player)
    {
        //stats
        playerSpeed = player.movementSpeed;
        jumpHeight = player.jumpHeight;
        health = player.Health;
        maxHealth = player.MaxHealth;
        level = player.Level;
        playerName = player.saveName;
        playerDate = player.saveDate;
        playerPercentage = player.savePercentage;

        //position
        position = new float[3];
        position[0] = player.pos.x;
        position[1] = player.pos.y;
        position[2] = player.pos.z;
        
        //rotation
        
        rotation = new float[3];
        if(player.rot.x < 0)
        {
            rotation[0] = player.rot.x * -1;
            xNegative = true;
        }
        else
        {
            rotation[0] = player.rot.x;
            xNegative = false;
        }
        rotation[1] = player.rot.y;
        rotation[2] = player.rot.z;
    }

}
