using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{

    [SerializeField] LayerMask hitMask;
    [SerializeField] float[] attackDelay;
    [SerializeField] float attackRadious = 1;
    [SerializeField] float offset;
    [SerializeField] float damage = 10;
    [SerializeField] GameObject mesh;
    [SerializeField] GameObject uiAmmo;
<<<<<<< HEAD
<<<<<<< HEAD
=======
    [SerializeField] float fieldOfView;
>>>>>>> fe6112479e7823e5a073fe96d65f34a52691b3f8
=======
>>>>>>> parent of fe61124... asd
    float currentAttack;
    bool isEquiped;
    PlayerFighting fighting;

    int attackIndex;
    Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        fighting = GetComponent<PlayerFighting>();
<<<<<<< HEAD
<<<<<<< HEAD
=======
        //OnEquip();
        cam.fieldOfView = fieldOfView;
        isEquiped = true;
>>>>>>> fe6112479e7823e5a073fe96d65f34a52691b3f8
=======
>>>>>>> parent of fe61124... asd
    }
    public void DisEquip()
    {
        mesh.SetActive(false);
        isEquiped = false;
        uiAmmo.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        currentAttack -= Time.deltaTime;
        if (isEquiped)
        {

            if (Input.GetButton("Fire1"))
            {
                if (currentAttack < 0)
                {
                    currentAttack = attackDelay[attackIndex];
                    Attack();
                    //Replace with Start Animation
                }

            }
        }

        if (Input.GetButtonDown("Melee"))
        {
            OnEquip();
        }
    }

    void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position + (offset * cam.transform.forward), attackRadious, hitMask);
        foreach (Collider obj in cols)
        {
            CharacterStats stat = obj.GetComponent<CharacterStats>();
            if (stat != null)
            {
                stat.TakeDamage(damage);
            }
        }
    }
    public void OnEquip()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        fighting.DisEquip();
        isEquiped = true;
        mesh.SetActive(true);
        uiAmmo.SetActive(false);
=======

        isEquiped = true;
        mesh.SetActive(true);
        uiAmmo.SetActive(false);
        cam.fieldOfView = fieldOfView;
        fighting.DisEquip();
>>>>>>> fe6112479e7823e5a073fe96d65f34a52691b3f8
=======
        fighting.DisEquip();
        isEquiped = true;
        mesh.SetActive(true);
        uiAmmo.SetActive(false);
>>>>>>> parent of fe61124... asd
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (cam != null)
            Gizmos.DrawWireSphere(transform.position + (offset * cam.transform.forward), attackRadious);

    }

}
