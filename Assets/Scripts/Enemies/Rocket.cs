using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float BulletSpeed;

    [SerializeField] GameObject player;
    
   
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
            //transform.position = Vector3.MoveTowards(transform.position, Plaayer.transform.position, 10000f)*Time.deltaTime * BulletSpeed;


            if (Vector3.Distance(transform.position, player.transform.position) <= 10f)
            {
                Debug.Log("Destroying");
                //character.TakeDamage(damage);
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }


        }
        else
        {
            Destroy(gameObject);
        } }

        void OnTriggerEnter(Collider col)
        {
        if(col.tag == "Player")
        {
            Destroy(gameObject);
        }
        }
    
}
