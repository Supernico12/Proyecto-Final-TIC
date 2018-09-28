using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    private float distance;

    public float radius;
    public Transform player;
    public float enemyDamage;
    CharacterStats playerHealth;
    public float maxRange;
    private bool onCooldown = false;

    // Use this for initialization
    void Start () {
      player =  PlayerManager.instance.playertransform;
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance < radius)
        {
            if (!onCooldown)
            {
                
                Attack();
                 
                onCooldown = true;
            }
        }
        if (onCooldown)
        {
            StartCoroutine(Delay(5f));
        }
    }

   

    IEnumerator Delay(float time)
    {
        
        yield return new WaitForSeconds(time);
        
    }

    public void Attack()
    {

        doDamage();
    }
    public void doDamage()
    {
        Debug.Log("Damage");
        playerHealth.TakeDamage(enemyDamage);
    }
}
