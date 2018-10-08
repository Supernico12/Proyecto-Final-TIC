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

        inventory.AddAmmo(10, ammoType);
        base.Interact();
    }


    void GetRandomAmmoType()
    {

        int type = Random.Range(0, ammoTypesQuantity);
        ammoType = type;
		float  currenttotalWeight = 0;
		for(int i = 0; i < weights.Length ; i++){
			
			if(weights[i].weight < 0){
				weights[i].weight = 0;

			}
			weights[i].fromweight = currenttotalWeight;
			currenttotalWeight += weights[i].weight;
			weights[i].toweight = currenttotalWeight;

			
		}
		for(int i = 0; i < weights.Length ; i++){
			weights[i].probability = ( weights[i].weight/ totalWeight ) * 100;
		}


    }
    // Use this for initialization
    void Start()
    {
		GetRandomAmmoType();
        ammoTypesQuantity = System.Enum.GetNames(typeof(AmmoTypes)).Length;
        inventory = PlayerInventory.instance;
        mesh = GetComponent<MeshFilter>();
		
		mesh.mesh = ammoMeshes[ammoType];
    }

	public struct ammoWeight{
		public float weight;
		public float fromweight;
		public float toweight;
		public float probability;
	}

}
