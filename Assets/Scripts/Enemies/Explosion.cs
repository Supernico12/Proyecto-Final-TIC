using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : CharacterStats {

    public ParticleSystem explosion;

    public override void Die()
    {
        base.Die();
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
