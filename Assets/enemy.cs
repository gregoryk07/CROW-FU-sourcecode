using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    // Start is called before the first frame update
    void Awake()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        Player.instance.GetComponent<attacking>().enemys[Player.instance.GetComponent<attacking>().enemys.Length] = this; 
    }

    public void Damage(float _dmg)
    {
        health -= _dmg;
        Debug.Log("Dealed damage to " + name + " with " + _dmg + " damage.");
    }
}