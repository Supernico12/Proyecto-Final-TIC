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
    public GameObject laser;
    public GameObject attack;

    Rigidbody rb;

    EnemyMovement movement;

    
    // Use this for initialization
    void Start () {

        player =  PlayerManager.instance.playertransform;
        rb = GetComponentInParent<Rigidbody>();
        movement = FindObjectOfType<EnemyMovement>();
        laser.SetActive(false);
        attack.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(transform.position, player.position);
        if (distance < maxRange)
        {
            agent.enabled = false;
            laser.SetActive(true);
            StartCoroutine(Delay(2));
            attack.SetActive(true);
            
            Attack();
            StartCoroutine(Delay(6));

            
            if (onCooldown == false)
            {
                
                Attack();
                 
                onCooldown = true;
            }
        }
        else
        {
            agent.enabled = true;
            laser.SetActive(false);
            attack.SetActive(false);
        }
        if (onCooldown)
        {
            StartCoroutine(Delay(5));
            onCooldown = false;
        }


    }



        IEnumerator Delay(int time)
    {
        
        yield return new WaitForSecondsRealtime(time);
        
    }

    

    public void Attack()
    {
        attack.SetActive(true);        
    }
    public void doDamage()
    {
        Debug.Log("Damage");
        //playerHealth.TakeDamage(enemyDamage);
        
    }
}
