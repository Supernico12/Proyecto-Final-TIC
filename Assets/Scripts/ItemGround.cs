using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGround : MonoBehaviour
{   
    [SerializeField] float pullRange;
    [SerializeField] float interactRange;
    [SerializeField] float speed;
    [SerializeField] int maxAmmo;
    [SerializeField] Mesh[] ammoMeshes;


    AmmoScript ammo;
    PlayerInventory inventory;
    Transform player;
    MeshFilter mesh;
    int ammoTypesQuantity;
    void Start()
    {
        ammoTypesQuantity =System.Enum.GetNames(typeof(AmmoTypes)).Length;
        player = PlayerManager.instance.player.transform;
        inventory = PlayerInventory.instance;
        mesh = GetComponent<MeshFilter>();
        ammo = new AmmoScript(
            (AmmoTypes)Random.Range(0f ,ammoTypesQuantity )
            ,10);
        
       mesh.mesh = ammoMeshes[(int)ammo.type];
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= pullRange)
        {
            Pull();
            if( distance <= interactRange){
                Interact();
            }
        }
    }
   
    void Pull()
    {
        transform.Translate((player.position -new Vector3(0,0.8f,0) - transform.position) * Time.deltaTime * speed);
       
    }

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position,interactRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,pullRange);
	}
    void Interact(){

        inventory.AddAmmo(ammo.quantity,(int)ammo.type);
        Destroy(gameObject);
    }
}
