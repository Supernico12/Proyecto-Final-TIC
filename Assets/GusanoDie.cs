using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GusanoDie : MonoBehaviour
{

    LevelManager level;
    [SerializeField]
    float health;


    public float currenthealth;
    [SerializeField] GameObject ammoDrop;


    public GameObject deathUI;

    public event System.Action OnTakeDamage;




    public void TakeDamage(float damage)
    {
        if (currenthealth - damage <= health)
        {
            currenthealth -= damage;
        }

        if (currenthealth <= 0)
        {
            if (deathUI == null) { 
            Die();
            }
            else
            { deathUI.SetActive(true); }
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
		SceneManager.LoadScene("EndGame");
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
    public float GetMaxHealth { 
   

        get
        {
            return health;

        }

    }

}
