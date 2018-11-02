using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject rocket;
    public GameObject firePoint1;
    public GameObject firePoint2;
    public GameObject firePoint3;
    int time;

    

    public float cooldown;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            time++;
        }
        if (time > cooldown)
        {
            Instantiate(rocket, firePoint1.transform.position, Quaternion.identity);
            Instantiate(rocket, firePoint2.transform.position, Quaternion.identity);
            Instantiate(rocket, firePoint3.transform.position, Quaternion.identity);
            time = 0;
        }
    }
    
}
