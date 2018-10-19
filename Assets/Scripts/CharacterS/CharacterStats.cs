using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{


	[SerializeField]
	float health;
    


	float currenthealth;
	[SerializeField] GameObject ammoDrop;

    Animator anim;

    



    
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


	public virtual void Die()
	{
        

		Instantiate(ammoDrop,transform.position,Quaternion.identity);
		Destroy(gameObject);
	}

	void Start()
	{
         
        anim = GetComponent<Animator>();
		currenthealth = health;

	}

}
