using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GunRecoil : MonoBehaviour {
    public Transform forceposition;
    public GameObject anchor;
    public Transform Controller;
    public Vector3 Addforce;
    SpringJoint spring;
    public float force;
    Rigidbody rb;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        spring = GetComponent<SpringJoint>();

        spring.connectedAnchor = anchor.transform.position;
        
	}

    Vector3 direction()
    {
        Vector3 dir = Controller.rotation.eulerAngles;
        
        Vector3 normalizd = dir.normalized;
        return -normalizd;
        
    }

   
    public void OnShoot()
    {
        Vector3 forceadd = direction() -Vector3.forward;
        Debug.Log(forceadd.ToString());
        rb.AddForceAtPosition(direction() * force, forceposition.position, ForceMode.Impulse);
    }
}
