﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{

    PlayerFighting playerFighting;
    Animator animator;
    AnimatorOverrideController overrideanimator;

    AnimationClip[] animationsClips;

    // 1 Shoot  2 Reload 3 Enter 4 Leave 

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        overrideanimator = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideanimator;
        playerFighting = PlayerManager.instance.player.GetComponent<PlayerFighting>();
        playerFighting.OnReload += OnReload;
        playerFighting.OnShoot += OnAttack;

    }


    void OnAttack()
    {
        animator.SetTrigger("Shoot");
        overrideanimator["Shoot"] = animationsClips[1];




    }

    void OnReload()
    { // need an Reload Finish to false

        animator.SetTrigger("Reload");
        overrideanimator["Reload"] = animationsClips[2];
        Debug.Log("Reloading");

    }



    public void SetAnimations(AnimationClip[] newClips)
    {
        animationsClips = newClips;
    }

    void LateUpdate()
    {
        gameObject.transform.localScale = new Vector3(1, 1, -1);
    }



}
