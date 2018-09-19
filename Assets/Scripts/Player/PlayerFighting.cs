using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighting : MonoBehaviour {

    [SerializeField]
    WeaponStats weapon;
    ParticleSystem muzzle;
    Camera cam;
   
	[SerializeField]
	Transform weaponsParent;
	float lastShot;
    PlayerAnimatorController playerAnimator;
	GameObject[] weaponMeshes; 
    int currentAmmo;
	bool isReloading;

    public event  System.Action OnReload;
    public event  System.Action OnShoot;
    
    //  public delegate void OnWeaponChanged()

      //  public del

    private void Start()
    {
        cam = Camera.main;

		//Testing
		int numberofWeaponsMeshes = System.Enum.GetNames(typeof(WeaponType)).Length;
		weaponMeshes = new GameObject[numberofWeaponsMeshes];
		playerAnimator = GetComponent<PlayerAnimatorController>();
		




		int i = 0;
		foreach (Transform weapons in weaponsParent.GetComponentsInChildren<Transform>(true))
		{
			
			if (weapons.gameObject.tag == "Weapon")
			{
				
				weaponMeshes[i] = weapons.gameObject;
				Debug.Log(weapons.name);
				i++;
			}
			
		}

		OnWeaponChange(weapon);


	}
	public void Shoot()
    {
        if (lastShot < Time.time)
        {
            if (currentAmmo > 0)
            {
                lastShot = Time.time + 1 / weapon.attackSpeed;
                Debug.Log("Shooting");

                currentAmmo--;
                if (muzzle != null)
                {
                    muzzle.Play();
                }

                // Shoot Sound place 
				//AkSoundEngine.PostEvent("Play_SMG_Shot", gameObject);
                RaycastHit hit;
				
                //recoil.OnShoot();
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range))
                {
                    ShotEffect(hit);
                    CharacterStats stats = hit.transform.GetComponent<CharacterStats>();
                    if (stats != null)
                    {
                        Attack(stats);
                    }
                }
            }else
            {
                StartCoroutine(Reload());
            }
        }

    }
	
    IEnumerator Reload()
    {
		// Despues Reemplazar con Envento En Recarga
		if (isReloading == false)
		{
			isReloading = true;
			yield return new WaitForSeconds(weapon.reloadDelay);
			currentAmmo = weapon.maxAmmo;
			isReloading = false;
            OnReload.Invoke();
		}
    }
   
    void Attack(CharacterStats enemyStats)
    {
        enemyStats.TakeDamage(weapon.damage);
    }
    public void OnWeaponChange(WeaponStats newWeapon )
    {

		int index = (int)newWeapon.weaponMesh;
		
       
        muzzle =Instantiate(newWeapon.shootMuzzle, weaponMeshes[index].transform);
        currentAmmo = newWeapon.maxAmmo; // Change to save last ammo usage
       

        foreach(Transform child in weaponMeshes[index].GetComponentsInChildren<Transform>())
        {
            if (child.name == "SpawnMuzzle")
            {
                muzzle.transform.position = child.transform.position;
            } 
			
        }
		weaponMeshes[(int)weapon.weaponMesh].SetActive(false);
		weaponMeshes[(int)newWeapon.weaponMesh].SetActive(true);

		weapon = newWeapon;
        playerAnimator.SetAnimations(newWeapon.animations);

	}

    public int  GetCurrentAmmo
    {
        get { return currentAmmo; }
    }
    // Update is called once per frame
    void ShotEffect(RaycastHit hit)
    {
        //  Debug.Log(hit.transform.name);
        if(weapon.hitParticle != null){
            Instantiate(weapon.hitParticle, hit.point, Quaternion.LookRotation(hit.normal),hit.transform);
			
        }
        
    }

    public WeaponStats GetCurrentWeapon {

        get { return weapon; }
    }
    void Update () {

        if (Input.GetButton("Reload"))
		{
			currentAmmo = 0;
			StartCoroutine(Reload());
		}
            if (weapon.isAutomatic)
            {
                if (Input.GetButton("Fire1"))
                {
                    Shoot();
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Shoot();
                }
            }
        }
        
	
}
