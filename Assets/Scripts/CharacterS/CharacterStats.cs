using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    LevelManager level;
    [SerializeField]
    float health;


    public float currenthealth;
    [SerializeField] GameObject ammoDrop;


<<<<<<< HEAD
=======

    public event System.Action OnTakeDamage;



>>>>>>> dc4086b6c2289fb37e678232e265986168cf2a67
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
        level.RemoveEnemy(1);
        Instantiate(ammoDrop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Start()
    {
        level = LevelManager.instance;
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
<<<<<<< HEAD
        return health;
=======
        get
        {
            return health;

        }
>>>>>>> dc4086b6c2289fb37e678232e265986168cf2a67
    }
}
