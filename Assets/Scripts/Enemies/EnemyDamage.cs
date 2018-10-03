using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Script Para el ataque de la Araña unicamente
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

    EnemyMovement movement;

   

    RaycastHit hit;
    // Use this for initialization
    void Start () {

        player =  PlayerManager.instance.playertransform;
        movement = FindObjectOfType<EnemyMovement>();
        laser.SetActive(false);
        attack.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance < maxRange)
        {
            Debug.Log(player.position);
            agent.enabled = false;
            
            
            laser.SetActive(true);
            Physics.Raycast(transform.position, player.position, out hit);
            Debug.DrawRay(transform.position, player.position);
            if (hit.collider.tag == "Player") {
                Debug.Log("Disparing Player");
                Attack();

             }

           // StartCoroutine(Delay(6));
             
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
        doDamage(enemyDamage);
    }
    public void doDamage(float damage)
    {
        Debug.Log("Damage");
        playerHealth.TakeDamage(damage);
        
    }
}
