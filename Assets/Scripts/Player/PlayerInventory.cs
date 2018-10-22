using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    #region Singleton
    public static PlayerInventory instance;
    void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("Trying To Instansiate More Than One Inventory");

        }
        else
        {
            instance = this;
        }

    }
    #endregion
    [SerializeField]
    Transform weaponsParent;

    List<WeaponStats> weapons = new List<WeaponStats>();
    [SerializeField]
    int[] ammo;
    int[] lastAmmo;
    [SerializeField]
    int[] maxAmmo;
    int index;

    PlayerFighting motor;
    PlayerMelee melee;


    private KeyCode[] NumberKeys = {
        // KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
     };
    void Start()
    {
        WeaponStats[] wp = weaponsParent.GetComponentsInChildren<WeaponStats>(true);
        foreach (WeaponStats weap in wp)
        {
            weapons.Add(weap);
        }

        melee = PlayerManager.instance.player.GetComponent<PlayerMelee>();
        ammo = new int[System.Enum.GetNames(typeof(AmmoTypes)).Length];
        motor = PlayerManager.instance.player.GetComponent<PlayerFighting>();

        lastAmmo = new int[weapons.Count];

        for (int i = 0; i < ammo.Length; i++)
        {
            lastAmmo[i] = weapons[i].maxAmmo;
        }

    }

    public void AddAmmo(int quantity, int i)
    {

        ammo[i] += quantity;
        if (ammo[i] > maxAmmo[i])
        {
            ammo[i] = maxAmmo[i];
        }
    }
    public void AddWeapon(WeaponStats newWeapon)
    {
        weapons.Add(newWeapon);
    }

    public int GetAmmo(int i)
    {
        return ammo[i];
    }


    public void AddLastAmmo(int quantity, WeaponStats weapon)
    {
        int index = GetWeaponIndex(weapon);
        if (index > -1)
        {
            lastAmmo[index] = quantity;

        }
    }

    public int GetLastAmmo(WeaponStats weapon)
    {
        int index = GetWeaponIndex(weapon);
        if (index > -1)
        {
            return lastAmmo[index];
        }
        return -1;
    }
    public void ChangeWeapon(int index)
    {
        if (weapons[index] != null)
        {
            motor.OnWeaponChange(weapons[index]);
        }

    }
    public WeaponStats GetWeapon(int i = 0)
    {
        return weapons[i];
    }
    int GetWeaponIndex(WeaponStats weapon)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapon.Gunname == weapons[i].Gunname)
            {
                return i;
            }
        }
        return -1;
    }
    void Update()
    {

        for (int i = 0; i < weapons.Count; i++)
        {
            if (Input.GetKeyDown(NumberKeys[i]))
            {
                int numberPressed = i;
                ChangeWeapon(i);
                index = i;
            }
        }
        float mouseScroll = (Input.GetAxis("Mouse ScrollWheel"));
        if (mouseScroll != 0)
        {
            index += (int)Mathf.Clamp(mouseScroll, -1, 1);
            if (index < 0)
            {
                melee.OnEquip();
            }
            else
            {
                index = Mathf.Clamp(index, 0, weapons.Count - 1);
                ChangeWeapon(index);
            }
        }

        //Debug.Log(index);
    }

    public float GetWeights(int i)
    {

        float porcentage = ammo[i] * 100 / maxAmmo[i];
        //Debug.Log(ammo[i] + "  " + maxAmmo[i]);

        porcentage = Mathf.Clamp(porcentage, 10f, 50);

        porcentage = 100 / porcentage;

        return porcentage;
    }



}
