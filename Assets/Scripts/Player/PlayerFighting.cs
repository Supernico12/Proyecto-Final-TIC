using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighting : MonoBehaviour
{

    [SerializeField]
    WeaponStats weapon;

    Camera cam;
    PlayerMelee melee;
    [SerializeField]
    Transform weaponsParent;
    float lastShot;
    PlayerAnimatorController playerAnimator;
    GameObject[] weaponMeshes;
    int currentAmmo;
    bool isReloading;
    PlayerInventory inventory;

    public event System.Action OnReload;
    public event System.Action OnShoot;

    public int arma;

    bool isEquiped;
    bool isScoped;
    float camerDefaultFieldOfView;
    //  public delegate void OnWeaponChanged()

    //  public del

    private void Start()
    {
        cam = Camera.main;
        camerDefaultFieldOfView = 80;
        //Testing
        int numberofWeaponsMeshes = System.Enum.GetNames(typeof(WeaponType)).Length;
        weaponMeshes = new GameObject[numberofWeaponsMeshes];

        inventory = PlayerInventory.instance;
        melee = GetComponent<PlayerMelee>();



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




    }
    public void Shoot()
    {
        if (lastShot < Time.time)
        {
            if (!isReloading)
            {
                if (currentAmmo > 0)
                {
                    lastShot = Time.time + 1 / weapon.attackSpeed;


                    currentAmmo--;
                    if (weapon.shootMuzzle != null)
                    {
                        weapon.shootMuzzle.Play();
                    }

                    // Shoot Sound place PREGUNTR NICOOOOOOOOOOOOOOOOOOO
                    arma = (int)weapon.type;

                    //AkSoundEngine.PostEvent("Play_SMG_Shot", gameObject);
                    RaycastHit hit;
                    if (OnShoot != null)
                        OnShoot.Invoke();
                    if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range))
                    {
                        ShotEffect(hit);
                        CharacterStats stats = hit.transform.GetComponent<CharacterStats>();
                        if (stats == null)
                        {
                            stats = hit.transform.GetComponentInParent<CharacterStats>();
                        }
                        if (stats != null)
                        {
                            Attack(stats);
                        }
                    }
                }
                else
                {
                    StartCoroutine(Reload());
                }
            }
        }

    }

    IEnumerator Reload()
    {
        // Despues Reemplazar con Envento En Recarga
        int index = (int)weapon.type;
        if (isReloading == false)
        {

            if (currentAmmo != weapon.maxAmmo)
            {

                if (inventory.GetAmmo(index) > 0)
                {

                    isReloading = true;
                    yield return new WaitForSeconds(weapon.reloadDelay);
                    //currentAmmo = weapon.maxAmmo;

                    int lastAmmo = currentAmmo;
                    currentAmmo += Mathf.Clamp(inventory.GetAmmo(index), 0, weapon.maxAmmo - currentAmmo);
                    inventory.AddAmmo(-currentAmmo + lastAmmo, index);

                    //Debug.Log(currentAmmo);
                    isReloading = false;
                    if (OnReload != null)
                        OnReload.Invoke();
                }
            }
        }
    }

    void Attack(CharacterStats enemyStats)
    {
        enemyStats.TakeDamage(weapon.damage);
    }


    public void OnWeaponChange(WeaponStats newWeapon)
    {

        int index = (int)newWeapon.weaponMesh;



        //muzzle = Instantiate(newWeapon.shootMuzzle, weaponMeshes[index].transform);
        // currentAmmo = newWeapon.maxAmmo; // Change to save last ammo usage
        inventory.AddLastAmmo(currentAmmo, weapon);
        currentAmmo = inventory.GetLastAmmo(newWeapon);
        cam.fieldOfView = camerDefaultFieldOfView;
        isScoped = false;
        isEquiped = true;
        melee.DisEquip();
        /*
                foreach (Transform child in weaponMeshes[index].GetComponentsInChildren<Transform>())
                {
                    if (child.name == "SpawnMuzzle")
                    {
                        muzzle.transform.position = child.transform.position;
                    }

                }
          */
        weaponMeshes[(int)weapon.weaponMesh].SetActive(false);
        weaponMeshes[(int)newWeapon.weaponMesh].SetActive(true);

        weapon = newWeapon;
        playerAnimator = weapon.GetComponent<PlayerAnimatorController>();
        if (playerAnimator != null)
            playerAnimator.SetAnimations(newWeapon.animations);

    }
    public void DisEquip()
    {
        isEquiped = false;
        weaponMeshes[(int)weapon.weaponMesh].SetActive(false);
    }
    public int GetCurrentAmmo
    {
        get { return currentAmmo; }
    }
    // Update is called once per frame
    void ShotEffect(RaycastHit hit)
    {
        //  Debug.Log(hit.transform.name);
        if (weapon.hitParticle != null)
        {
            GameObject shotpart = Instantiate(weapon.hitParticle, hit.point, Quaternion.LookRotation(hit.normal));
            shotpart.transform.parent = hit.transform;

        }

    }
    void Scope()
    {

        isScoped = !isScoped;

        if (isScoped)
        {

            cam.fieldOfView = weapon.scopeFieldOfView;

        }
        else
        {
            cam.fieldOfView = camerDefaultFieldOfView;
        }

    }

    public WeaponStats GetCurrentWeapon
    {

        get { return weapon; }
    }
    void Update()
    {
        if (isEquiped)
        {
            if (Input.GetButtonDown("Reload"))
            {
                //currentAmmo = 0;
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

            if (Input.GetButtonDown("Fire2"))
            {
                if (weapon.hasScope)
                {
                    Scope();
                }

            }
        }
    }


}
