﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public LevelManager level;
    [SerializeField]
    float health;


    public float currenthealth;
    [SerializeField] GameObject ammoDrop;



    public event System.Action OnTakeDamage;



    public void TakeDamage(float damage)
    {
        if (currenthealth - damage < health)
        {
            currenthealth -= damage;
        }

        if (currenthealth <= 0)
        {
            Die();
        }
        if (damage > 0)
        {
            if (OnTakeDamage != null)
                OnTakeDamage.Invoke();
        }
    }


    public virtual void Die()
    {
        level.RemoveEnemy(0);
        Instantiate(ammoDrop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Start()
    {
        currenthealth = health;
        if (level != null)
            level.AddEnemy(1);
    }

    public float GetHealth
    {
        get
        {
            return currenthealth;

        }
    }
    public float GetMaxHealth
    {
        get
        {
            return health;

        }
    }
}
