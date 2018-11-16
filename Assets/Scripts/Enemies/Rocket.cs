using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float BulletSpeed;

    [SerializeField] GameObject player;

    public float damage;
    CharacterStats character;

    public ParticleSystem explosion;

    void Start()
    {
        player = PlayerManager.instance.player;
        
        character = player.GetComponent<CharacterStats>();
        
        
    }
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform.position);
            transform.position += transform.forward * BulletSpeed * Time.deltaTime;
            

            if (Vector3.Distance(transform.position, player.transform.position) <= 8f)
            {
              
                Instantiate(explosion, transform.position, Quaternion.identity);
                character.TakeDamage(damage);
                Destroy(gameObject);

            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

        void OnTriggerEnter(Collider col)
        {
            if(col.tag == "Player")
            {
                Destroy(gameObject);
            }
        }  
}
