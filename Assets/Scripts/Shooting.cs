using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour {

     Camera cam;
    public float MaxDistance;
    public GameObject HitParticles;
    public ParticleSystem Muzzle;
    public Transform MuzzleSpawnPosition;
    public float ShootDelay;
    float currenttime;

    

    void Start()
    {
        cam = Camera.main;
        
    }

    void Update()
    {
        

        if (Input.GetButton("Fire1") )
        {
            if (currenttime < Time.time)
            {
                currenttime = Time.time + 1 / ShootDelay;
                Shoot();
            }
            
        }

       
    }
    void Shoot()
    {
        
        RaycastHit hit;
        Muzzle.Play();
       // recoil.OnShoot();
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, MaxDistance))
        {
            ShotEffect(hit);
        }
          
        
    }

    void ShotEffect(RaycastHit hit)
    {
       //  Debug.Log(hit.transform.name);
        Instantiate(HitParticles, hit.point, Quaternion.LookRotation(hit.normal));
    }

    
}
