using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{


	[SerializeField]
	float health;
<<<<<<< HEAD
=======
    
>>>>>>> parent of fd76056... Merge branch 'master' of https://github.com/Supernico12/Proyecto-Final-TIC


	float currenthealth;
	[SerializeField] GameObject ammoDrop;


<<<<<<< HEAD
	




=======
    



    
>>>>>>> parent of fd76056... Merge branch 'master' of https://github.com/Supernico12/Proyecto-Final-TIC
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
		
		Instantiate(ammoDrop,transform.position,Quaternion.identity);
		Destroy(gameObject);
	}

	void Start()
	{
		currenthealth = health;

	}

}
