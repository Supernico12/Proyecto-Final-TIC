using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour {

    EnemyDamage attack;
    void OnCollisionEnter (Collider col)
    {
        if (col.tag == "Player")
        {
            attack.Attack();
        }
    }
}
