using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public bool isActive;
    public float dmg;
    public float attackRate;
    public float range;
    public bool canHoldAttack = false;
    [Tooltip("In seconds")] public float animTime = 1;
    public GameObject graph;
    public Animator anim;
    attacking attacking;
    public bool doAttack;
    bool attacked;
    public float attackTime;
    float dmgbuff = 1, ratebuff = 1;


    private void Awake()
    {
        attacking = Player.instance.GetComponent<attacking>();
    }

    void Update()
    {
        graph.SetActive(isActive);
        if (doAttack)
        {
            if (!attacked)
            {
                attackTime = Time.time;
                attacked = true;
            }
            if (Time.time < attackTime + (attackTime * ratebuff))
            {
                AttackEnemy(dmgbuff);
            }
            else
            {
                doAttack = false;
                attacked = false;
                Debug.Log("Successfully finished a " + attackTime * ratebuff + " second attack");
            }
        }
    }
    public void AttackEnemy(float _dmgBuffMultiplier)
    {
        for (int i = 0; i < Player.instance.GetComponent<attacking>().enemys.Length; i++)
        {
            if (Physics2D.IsTouching(GetComponent<Collider2D>(), attacking.enemys[i].GetComponent<Collider2D>()))
            {
                attacking.enemys[i].Damage(dmg * _dmgBuffMultiplier);
            }
        }
    }
    public void Attack(float _dmgBuff, float _rateBuff)
    {
        doAttack = true;
        attacked = false;
        dmgbuff = _dmgBuff;
        ratebuff = _rateBuff;
    }
}