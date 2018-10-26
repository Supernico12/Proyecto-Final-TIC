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
    [SerializeField] float fieldOfView;
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
        //OnEquip();
        cam.fieldOfView = fieldOfView;
        isEquiped = true;
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

        isEquiped = true;
        mesh.SetActive(true);
        uiAmmo.SetActive(false);
        cam.fieldOfView = fieldOfView;
        fighting.DisEquip();
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (cam != null)
            Gizmos.DrawWireSphere(transform.position + (offset * cam.transform.forward), attackRadious);

    }

}
