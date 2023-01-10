using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacking : MonoBehaviour
{
    [HideInInspector] public enemy[] enemys;
    public weapon[] weapons;
    public int currentWeapon = 0;
    public int defaultWeapon = 0;
    public KeyCode attackButton = KeyCode.Mouse0;
    public KeyCode[] weaponButtons = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].isActive = false;
        }
        weapons[defaultWeapon].isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            if (Input.GetKeyDown(weaponButtons[i]))
            {
                if (i > weapons.Length)
                {
                    for (int j = 0; i < weapons.Length; i++)
                    {
                        weapons[j].isActive = false;
                    }
                    weapons[i].isActive = true;
                    currentWeapon = i;
                }
                else
                {
                    Debug.Log($"Not enough weapons... ({i+1})");
                }
            }
        }

        if (currentWeapon <= weapons.Length)
        {
            if (weapons[currentWeapon].canHoldAttack)
            {
                if (Input.GetKey(attackButton))
                {
                    //TODO Damage on hold;
                }
            }
            else
            {
                if (Input.GetKeyDown(attackButton))
                {
                    weapons[currentWeapon].Attack(1, 1);
                }
            }
        }
    }
}
