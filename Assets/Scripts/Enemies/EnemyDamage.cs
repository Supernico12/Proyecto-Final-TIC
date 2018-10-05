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
    private bool attacking = false;

    public NavMeshAgent agent;
    
    Transform firePoint;
    Transform lastPos;


    EnemyMovement movement;

    #region Line
    public LineRenderer line;
    public LineRenderer attack;
    #endregion 
    RaycastHit hit;
    #region Timer
    int time1;
    public int Cooldown;

    #endregion


    // Use this for initialization
    void Start () {

        firePoint = GameObject.Find("FirePoint").transform;
        player =  PlayerManager.instance.playertransform;
       
      

    }
	
	// Update is called once per frame
	void Update () {

        
        distance = Vector3.Distance(firePoint.position, player.position);
        
            if (distance < maxRange)
            {
                Attack();
               
            }
            else
            {
                agent.enabled = true;
                
                line.SetPosition(0, new Vector3(0f, 0f, 0f));
                line.SetPosition(1, new Vector3(0f, 0f, 0f));
            
        }
    }

    public void Attack()
    {
        time1++;
        agent.enabled = false;
        if (!attacking)
        {
            lastPos = player;
            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, player.position);
            if(time1 > Cooldown)
            {
                attacking = true;
                CastRay();
                time1 = 0;
            }

        }
       
    }

    public void CastRay()
    {
        attack.SetPosition(0, firePoint.position);
        attack.SetPosition(1, lastPos.position);
        if (attack.GetPosition(1) == lastPos.position)
        {

            Debug.Log("Disparing Player");
            playerHealth.TakeDamage(enemyDamage);

        } else
        {
            Debug.Log("Attack Missed");
        }
        if (time1 > Cooldown - 25)
        {
            attacking = false;
            attack.SetPosition(0, new Vector3(0f, 0f, 0f));
            attack.SetPosition(1, new Vector3(0f, 0f, 0f));
        }
    }
}
