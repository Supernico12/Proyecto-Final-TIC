using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationReciver : MonoBehaviour
{

    PlayerMelee melee;

    public void FinishAttack()
    {
        melee.FinishAttack();
    }

    void Start()
    {
        melee = GetComponentInParent<PlayerMelee>();
    }
}
