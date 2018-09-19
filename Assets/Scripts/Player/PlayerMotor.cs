using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	CharacterController characterController;
	Camera cam;
	Rigidbody rb;
	[SerializeField] float speed = 1;
	[SerializeField] float gravity = -1;
	[SerializeField] float jumpSpeed = 8;
	[SerializeField] Vector2 maxRotations;
	[SerializeField] float sensibility;

	Vector3 movement;
	
	void Start () {
		cam = Camera.main;	
		rb = GetComponent<Rigidbody>();
		characterController = GetComponent<CharacterController>();
		 Cursor.lockState = CursorLockMode.Locked;
		

	}
	
	void Move(){
		Vector3 camF = cam.transform.forward;
		Vector3 camR = cam.transform.right;
		camF.y = 0;
		camR.y = 0;
		camF = camF.normalized;
		camR = camR.normalized; 

		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		Vector3 finalMov = (input.y * camF + input.x * camR) * speed * Time.deltaTime;
		characterController.Move(new Vector3(finalMov.x , movement.y , finalMov.z) );
	}
	// Update is called once per frame
	void Jump(){
		if(Input.GetButton("Jump")){
			movement.y = jumpSpeed ;
			Debug.Log("Jumping");
		}
	}
	void RotateCamera(){
		Vector2 rot = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")  );
		//rot.y = Mathf.Clamp( rot.y , maxRotations.x , maxRotations.y);

		cam.transform.eulerAngles += new Vector3 (-rot.y ,rot.x  ,0)* sensibility;

	}
	void Update(){
		RotateCamera();
	}
	void FixedUpdate () {
		Move();

		if(characterController.isGrounded){
			
			
			movement.y = 0;
			Jump();
		}else{
			movement.y += gravity * Time.deltaTime; 
			 movement.y = Mathf.Clamp(movement.y, -10 , 10);
			
		}
	}
}
