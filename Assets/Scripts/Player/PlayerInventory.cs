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
    List<WeaponStats> weapons = new List<WeaponStats>();
    [SerializeField]
    int[] ammo;
    int[] lastAmmo;
    [SerializeField]
    int[] maxAmmo;

    PlayerFighting motor;


    private KeyCode[] NumberKeys = {
         KeyCode.Alpha1,
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
        motor = PlayerManager.instance.player.GetComponent<PlayerFighting>();
        ammo = new int[System.Enum.GetNames(typeof(AmmoTypes)).Length];
        lastAmmo = new int[weapons.Count];

        for(int i = 0 ; i < ammo.Length; i++){
            AddAmmo(weapons[i].maxAmmo , i);
        }

    }

    public void AddAmmo(int quantity, int i)
    {
        
        ammo[i] += quantity;
        if(ammo[i] > maxAmmo[i]){
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
		if(index > -1){
			lastAmmo[index] = quantity;

		}
    }

	public int GetLastAmmo(WeaponStats weapon){
		int index = GetWeaponIndex(weapon);
		if(index > -1){
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
    int GetWeaponIndex(WeaponStats weapon)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapon.name == weapons[i].name)
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
                int numberPressed = i + 1;
                ChangeWeapon(i);

            }
        }
    }





}
