using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public float BulletSpeed;

    Vector3 targeteano;
    public GameObject player;
    Rigidbody rb;
    public int timebeforedestroy;
    int time;

    public float damage;

    public ParticleSystem explosion;

    CharacterStats character;

    void Start()
    {
<<<<<<< HEAD
        player = PlayerManager.instance.player;

        character = player.GetComponent<CharacterStats>();
        
        

        

    }
    void FixedUpdate()
    {


        transform.LookAt(player.transform.position);

        Debug.Log("Distance" + Vector3.Distance(transform.position, player.transform.position));
       
    }
    void Update()
    {

        transform.position += transform.forward * BulletSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, player.transform.position) <= 4f)
        {
            Debug.Log("Destroying");
            //character.TakeDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

=======
        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        targeteano = player.transform.position - transform.position;
    }
    void FixedUpdate()
    {
        
        rb.velocity = targeteano.normalized * BulletSpeed * Time.deltaTime;
        


    }
    void Update()
    {
        
>>>>>>> 3432a3a2b291b935617229450ee0a44eeda93337
        time++;
        if (time > timebeforedestroy)
        {
            Destroy(gameObject);
            time = 0;
        }
    }
}
