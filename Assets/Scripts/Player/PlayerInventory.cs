using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	#region Singleton
		public static PlayerInventory instance;
		void Awake(){
			
			if(instance != null){
				Debug.LogWarning("Trying To Instansiate More Than One Inventory");
			
			}else {
					instance = this;
			}
		
		}
	#endregion

	[SerializeField]
	List<WeaponStats> weapons = new List <WeaponStats>();
	[SerializeField]
	int[] ammo;

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

	}

	public void AddAmmo(int quantity, int i){
		ammo[i] += quantity;
	}
	public void AddWeapon(WeaponStats newWeapon)
	{
		weapons.Add(newWeapon); 
	}

	
	public void ChangeWeapon(int index)
	{
		if (weapons[index] != null)
		{
			motor.OnWeaponChange(weapons[index]);
		}
		
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
