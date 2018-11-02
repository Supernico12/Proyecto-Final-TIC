using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    LevelManager level;
    [SerializeField]
    float health;


    float currenthealth;
    [SerializeField] GameObject ammoDrop;


    public void TakeDamage(float damage)
    {
        currenthealth -= damage;
        
        if (currenthealth <= 0)
        {
            Die();
        }
    }


    public virtual void Die()
    {
        level.RemoveEnemy(1);
        Instantiate(ammoDrop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Start()
    {
        level = LevelManager.instance;
        currenthealth = health;
        level.AddEnemy(1);
    }

    public float GetHealth
    {
        get {
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
