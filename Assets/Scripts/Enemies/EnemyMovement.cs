


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//

public class EnemyMovement : MonoBehaviour {



    

    public Transform player;
    GameObject enemy;
    [SerializeField]
    int range;
    int distance;
    public float speed;
    public NavMeshAgent agent;
    Vector3 destination;
    public bool canMove = true;

    // Use this for initialization
    void Start()
    {
        Debug.Log(player);
       player = PlayerManager.instance.playertransform;
       agent = GetComponent<NavMeshAgent>();
        

    }
       

    // Update is called once per frame
    void Update()
    {
    
         if  (Vector3.Distance(transform.position,player.position) < range)
         {
                destination = new Vector3(player.position.x, transform.position.y, player.position.z);
                FollowPlayer(destination);
         }
      


    }

    public void FollowPlayer (Vector3 target)
    {
        agent.SetDestination(target);
        
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}

