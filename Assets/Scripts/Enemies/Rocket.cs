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
            GameObject restos = Instantiate(explosion, transform.position, Quaternion.identity).GetComponent<GameObject>();
            Destroy(restos, 3);
            Destroy(gameObject);
            
        }

        time++;
        if (time > timebeforedestroy)
        {
            Destroy(gameObject);
            time = 0;
        }
    }
}
