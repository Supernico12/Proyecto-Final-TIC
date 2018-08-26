using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public virtual void Interact()
    {
        Debug.Log("interacting with: " + gameObject.name);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
