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


    void Start()
    {

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
            Instantiate(explosion, transform.position, Quaternion.identity);
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
*/