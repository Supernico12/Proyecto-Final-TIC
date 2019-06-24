using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject rocket;
    public GameObject firePoint1;
    
    float time;

    

    public float cooldown;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            time += Time.deltaTime;
        }
        if (time > cooldown)
        {
            Instantiate(rocket, firePoint1.transform.position, Quaternion.identity);
            
            time = 0;
        }
    }
    
}
