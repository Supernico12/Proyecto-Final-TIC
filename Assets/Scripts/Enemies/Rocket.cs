using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public float BulletSpeed;

    Vector3 targeteano;
    Transform player;
    Rigidbody rb;
    public int timebeforedestroy;
    int time;
    

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        targeteano = player.transform.position - transform.position;



    }
    void FixedUpdate()
    {



        transform.LookAt(player.transform.position);



    }
    void Update()
    {

        transform.position += transform.forward * BulletSpeed * Time.deltaTime;

        time++;
        if (time > timebeforedestroy)
        {
            Destroy(gameObject);
            time = 0;
        }
    }
}
