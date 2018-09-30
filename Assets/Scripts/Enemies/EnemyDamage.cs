using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyDamage : MonoBehaviour {

    private float distance;

    public float radius;
    public Transform player;
    public float enemyDamage;
    CharacterStats playerHealth;
    public float maxRange;
    private bool onCooldown = false;
    public NavMeshAgent agent;


    Rigidbody rb;
    EnemyMovement movement;
    // Use this for initialization
    void Start () {

        player =  PlayerManager.instance.playertransform;
        rb = GetComponentInParent<Rigidbody>();
        movement = FindObjectOfType<EnemyMovement>();
    }
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(transform.position, player.position);
        if (distance < maxRange)
        {
            agent.enabled = false;
            //AlertLaser
            //CastAttack
            //WaitCd

            
            if (onCooldown == false)
            {
                
                Attack();
                 
                onCooldown = true;
            }
        }
        else
        {
            agent.enabled = true;
        }
        if (onCooldown)
        {
            StartCoroutine(Delay(50f));
            onCooldown = false;
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
        //playerHealth.TakeDamage(enemyDamage);
        
    }
}
