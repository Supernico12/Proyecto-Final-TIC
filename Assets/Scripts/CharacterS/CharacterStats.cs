using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{


<<<<<<< HEAD
    [SerializeField]
    float health;
=======
	[SerializeField]
	float health;
    
>>>>>>> 2b16ca68d2adda29811d496a53c094b3bed07da9


    float currenthealth;
    [SerializeField] GameObject ammoDrop;

    Animator anim;

<<<<<<< HEAD




=======
    



    
	public void TakeDamage(float damage)
	{
		currenthealth -= damage;
		if (currenthealth <= 0)
		{
            
            if (anim != null)
                Debug.Log("Die" + anim.GetBool("Die"));
                anim.SetBool("Die", true);
        }
	}
>>>>>>> 2b16ca68d2adda29811d496a53c094b3bed07da9

    public void TakeDamage(float damage)
    {
        currenthealth -= damage;
        Debug.Log(currenthealth);
        if (currenthealth <= 0)
        {
            Die();
        }
    }

<<<<<<< HEAD

    public virtual void Die()
    {
=======
	public virtual void Die()
	{
        

		Instantiate(ammoDrop,transform.position,Quaternion.identity);
		Destroy(gameObject);
	}

	void Start()
	{
         
        anim = GetComponent<Animator>();
		currenthealth = health;
>>>>>>> 2b16ca68d2adda29811d496a53c094b3bed07da9

        Instantiate(ammoDrop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Start()
    {
        currenthealth = health;

    }

}
