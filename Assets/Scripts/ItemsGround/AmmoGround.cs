using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoGround : ItemGround
{

    int ammoTypesQuantity;
    [SerializeField] Mesh[] ammoMeshes;
    MeshFilter mesh;
    PlayerInventory inventory;
    int ammoType;

	float totalWeight;
	
	[SerializeField]
	ammoWeight[]  weights; 
	
	
    public override void Interact()
    {
	
        inventory.AddAmmo(inventory.GetWeapon(ammoType).maxAmmo,ammoType);
        base.Interact();
		
    }


    void GetRandomAmmoType()
    {

        //int type = Random.Range(0, ammoTypesQuantity);
        //ammoType = type;
		float  currenttotalWeight = 0;
		for(int i = 0; i < weights.Length ; i++){
			
			if(weights[i].weight < 0){
				weights[i].weight = 0;

			}
			weights[i].fromweight = currenttotalWeight;
			currenttotalWeight += weights[i].weight;
			weights[i].toweight = currenttotalWeight;

			
		}
		totalWeight = currenttotalWeight;
		for(int i = 0; i < weights.Length ; i++){
			weights[i].probability = ( weights[i].weight/ totalWeight ) * 100;
			//Debug.Log(weights[i].probability);

		}
		float pickNumber = Random.Range(0,totalWeight);

		for(int i = 0 ; i < weights.Length ; i++){
			if(pickNumber > weights[i].fromweight && pickNumber < weights[i].toweight){
				ammoType = i;
			}
		}

    }
    // Use this for initialization
    void Start()
    {
		player = PlayerManager.instance.player.transform;
        ammoTypesQuantity = System.Enum.GetNames(typeof(AmmoTypes)).Length;
        inventory = PlayerInventory.instance;
        mesh = GetComponent<MeshFilter>();
		SetWeights();
		GetRandomAmmoType();
			
			mesh.mesh = ammoMeshes[ammoType];

    }

	public void SetWeights(){
		weights = new ammoWeight[ammoTypesQuantity];
		for(int i = 0;  i  < ammoTypesQuantity ; i++){
			
			 weights[i].weight = inventory.GetWeights(i);
			 Debug.Log( i + " : " + weights[i].weight  );
			
		}
	} 
[System.Serializable]
	public struct ammoWeight{
		public float weight;
		public float fromweight;
		public float toweight;
		public float probability;
	}

}
