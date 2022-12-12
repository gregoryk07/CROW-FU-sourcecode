using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statsManager : MonoBehaviour
{
    public static statsManager instance;
    public int Health;
    public int MaxHealth;
    public float Level;
    public Vector3 pos = Vector3.zero;
    public Vector3 rot = Vector3.zero;
    public string saveName = "Player";
    public string saveDate;
    public float savePercentage;
    public float movementSpeed;
    public float jumpHeight;
    //defaults
    int defHealth = 6;
    int defMaxHealth = 6;
    float defLevel = 0f;
    Vector3 defpos = new Vector3(0, 6.69f, 0);
    Vector3 defrot = Vector3.zero;
    float defsavePercentage = 0f;
    float defmovementSpeed = 10f;
    float defjumpHeight = 2.5f;

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
        Health = defHealth;
        MaxHealth = defMaxHealth;
        Level = defLevel;
        pos = defpos;
        rot = defrot;
        savePercentage = defsavePercentage;
        movementSpeed = defmovementSpeed;
        jumpHeight = defjumpHeight;
    }
}
