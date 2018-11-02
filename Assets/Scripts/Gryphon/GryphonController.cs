using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GryphonController : MonoBehaviour
{

    Animator animatorControlller;
    bool isFlying;
    Transform player;



    public void StartFlying()
    {
        // animatorControlller.SetBool("SetOFF", true);
        isFlying = true;
    }

    void Update()
    {

    }

    void GrabPlayer()
    {
        player.parent = transform;
    }

    void Start()
    {
        animatorControlller = GetComponent<Animator>();
        player = PlayerManager.instance.player.transform;
    }
}
