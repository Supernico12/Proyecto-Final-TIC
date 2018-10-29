/*/using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float BulletSpeed;

    Vector3 targeteano;
    Transform player;
    Rigidbody rb;
    public int timebeforedestroy;
    int time;

<<<<<<< HEAD
    public float damage;

    public ParticleSystem explosion;

    
    CharacterStats character;

    void Start()
    {
        player = PlayerManager.instance.player;
=======

    void Start()
    {
>>>>>>> fe6112479e7823e5a073fe96d65f34a52691b3f8

        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        targeteano = player.transform.position - transform.position;
    }

    void FixedUpdate()
    {


        transform.LookAt(player.transform.position);
        rb.velocity = targeteano.normalized * BulletSpeed * Time.deltaTime;

        Debug.Log("Distance" + Vector3.Distance(transform.position, player.transform.position));

    }
    void Update()
    {

        transform.position += transform.forward * BulletSpeed * Time.deltaTime;
        player = PlayerManager.instance.player;

        character = player.GetComponent<CharacterStats>();
        if (Vector3.Distance(transform.position, player.transform.position) <= 4f)
        {
            Debug.Log("Destroying");
            //character.TakeDamage(damage);
            GameObject restos = Instantiate(explosion, transform.position, Quaternion.identity).GetComponent<GameObject>();
            Destroy(restos, 3);
            Destroy(gameObject);
            
        }

<<<<<<< HEAD
=======

>>>>>>> fe6112479e7823e5a073fe96d65f34a52691b3f8
        time++;
        if (time > timebeforedestroy)
        {
            Destroy(gameObject);
            time = 0;
        }
    }
}
*/