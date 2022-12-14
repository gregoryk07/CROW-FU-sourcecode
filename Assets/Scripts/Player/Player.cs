using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [Header("From savefile")]
    public int health, maxHealth;
    public float level;
    public float MovementSpeed;
    public float JumpHeight;
    public Vector3 playerPos;
    public Quaternion playerRot;
    public float savePercentage;
    public playerMovement movement;
    PlayerData data;
    [Header("Values that don't come from saves")]
    public float curPower = 0f;
    public float maxPower = 4f;
    public float powerRegenTime = 0.04f;
    [Header("To asign")]
    public Transform cam;

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
        
    }
    public void Start()
    {
        curSaveInfo save = curSaveInfo.instance;
        health = save.saveHealth;
        maxHealth = save.saveMaxHealth;
        level = save.saveLevel;
        Vector3 pos = save.savePos;
        Vector3 rot = save.saveRot;
        playerPos = pos;
        MovementSpeed = save.movementSpeed;
        JumpHeight = save.jumpHeight;
        movement.GetComponent<Transform>().position = pos;
        cam.position = pos;


        if (movement == null)
        {
            movement = GetComponent<playerMovement>();
        }
    }

    private void Update()
    {
        curSaveInfo.instance.savePos = transform.position;
        curSaveInfo.instance.saveRot = transform.eulerAngles;

        curPower = Mathf.Lerp(curPower, maxPower + 0.5f, powerRegenTime * Time.fixedDeltaTime);

        curPower = Mathf.Clamp(curPower, 0f, 3f);

        UpdateUI();
    }

    void UpdateUI()
    {
        UIElements.instance.healthSlider.value = health;
        UIElements.instance.KiPowerSlider.value = curPower;
    }
}
