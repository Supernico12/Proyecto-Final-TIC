﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Weapons", menuName = "Inventory/Weapons")]
public class WeaponStats : ScriptableObject {



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
	public WeaponMesh weaponMesh;
    [SerializeField]
    public AnimationClip[] animations;
    // 1 Shoot  2 Reload 3 Enter 4 Leave 
	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	 
	
}
public enum WeaponMesh { Pistol, Rifle, Heavy, Sniper };