using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {


    [SerializeField]
    float interactRange;
    Camera cam;
	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	

    void Interact() {
        RaycastHit hit;
       if( Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange)){
           Interactable interactable = hit.transform.GetComponent<Interactable>();
            if(interactable != null)
            {
                interactable.Interact();
            }
        }

    }
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Interact")){
            Interact();
        }
	}
}
