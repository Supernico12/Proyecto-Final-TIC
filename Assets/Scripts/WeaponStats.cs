using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class WeaponStats : MonoBehaviour
{



    public string Gunname;
    public float attackSpeed;
    public float damage;
    public bool isAutomatic;
    public float range;
    public ParticleSystem shootMuzzle;
    public GameObject hitParticle;
    public int maxAmmo;
    public int reloadDelay;
    [SerializeField]
    public WeaponType weaponMesh;
    [SerializeField]
    public AnimationClip[] animations;
    public WeaponType type;

    [Header("Scope")]
    public bool hasScope;
    public float scopeFieldOfView;


    // 1 Shoot  2 Reload 3 Enter 4 Leave 5 Idle
    // Use this for initialization




}
public enum WeaponType { Pistol, Rifle, Heavy, Sniper };
public enum AmmoTypes { PistolAmmo, RifleAmmo, HeavyAmmo, SniperAmmo }