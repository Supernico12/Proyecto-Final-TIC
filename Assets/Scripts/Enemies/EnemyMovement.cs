using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public GameObject character;
    private Transform player;
    [SerializeField]
    int range;
    Vector3 distance;
    //public NavMeshAgent agent;
    // Use this for initialization}
    int speed = 10;
    void Start()
    {
        Debug.Log(player);
       player = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = character.transform.position;
        if (Vector3.Distance(this.gameObject.transform.position, distance) < range)
        {
            // Debug.Log("In");
            Vector3.MoveTowards(this.gameObject.transform.position, distance, speed);
        }
       
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

