using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof ( Animator))]
public class AutomaticDoor : MonoBehaviour {
    [SerializeField]
    float interactRadious;

    bool isOpen;

    Animator animator;
    Transform player; 
    
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        player = PlayerManager.instance.playertransform;
	}

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
       
        if( distance < interactRadious && !isOpen)
        {
            Open();
        }
        
        if(distance > interactRadious &&  isOpen)
        {
            Close();
        }

    }
    void OnDrawGizmos()
       {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactRadious);
        }

    void Open()
    {
        animator.SetBool("isOpen", true);
        isOpen = true;
    }
    void Close()
    {
        animator.SetBool("isOpen", false);
        isOpen = false;
    }
}
