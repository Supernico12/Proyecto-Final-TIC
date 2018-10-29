using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{


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
		
		Instantiate(ammoDrop,transform.position,Quaternion.identity);
		Destroy(gameObject);
	}

	void Start()
	{
		currenthealth = health;

	}

}
