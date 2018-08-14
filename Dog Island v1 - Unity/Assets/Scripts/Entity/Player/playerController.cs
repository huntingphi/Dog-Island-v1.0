using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	/*
	 * instances
	 */


	public float moveSpeed;
	public float gravityScale;
	public float jumpForce;
	public CharacterController controller;

	private Vector3 moveDirection;
	private bool canAirJump = true;

	public Animator anim;
	public Transform camera;
	public Transform characterModel;
	public float rotateSpeed;


	public GameObject respawnManager;


	/*
	 * methods
	 */

	void Start () 
	{
		controller = GetComponent<CharacterController>();
		canAirJump = true;

		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () 
	{
		Movement();

		// handle animations
		anim.SetBool("isGrounded", controller.isGrounded);
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")));
	}


	// input is turned into player movement on screen
	void Movement()
	{
		moveDirection = (transform.forward * Input.GetAxis("Vertical") * moveSpeed)
						+ (transform.right * Input.GetAxis("Horizontal") * moveSpeed);


		if(!controller.isGrounded)
		{
			moveDirection = (transform.forward * Input.GetAxis("Vertical") * moveSpeed * 0.8f)
							+ (transform.right * Input.GetAxis("Horizontal") * moveSpeed * 0.8f) 
							+ new Vector3(0, controller.velocity.y, 0);				
		}
			
		if (Input.GetButtonDown ("Jump")) 
		{
			if (controller.isGrounded) 
			{
				canAirJump = true;
				moveDirection.y = jumpForce;
			}
			else if(canAirJump)
			{
				canAirJump = false;
				moveDirection.y = jumpForce;
			}
		}

		if(Input.GetKeyDown("escape"))
		{
			Cursor.lockState = CursorLockMode.None;
		}			

		moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
		controller.Move(moveDirection * Time.deltaTime);

		// Move the player in different directions
		if(Input.GetAxisRaw("Horizontal") > 0)
		{
			characterModel.rotation  = Quaternion.Euler(0f, camera.rotation.eulerAngles.y + 90f, 0f);
		}
		else if(Input.GetAxisRaw("Horizontal") < 0)
		{
			characterModel.rotation  = Quaternion.Euler(0f, camera.rotation.eulerAngles.y - 90f, 0f);
		}
		else if(Input.GetAxisRaw("Vertical") < 0)
		{
			characterModel.rotation  = Quaternion.Euler(0f, camera.rotation.eulerAngles.y + 180f, 0f);
		}
		else if(Input.GetAxisRaw("Vertical") > 0)
		{
			characterModel.rotation  = Quaternion.Euler(0f, camera.rotation.eulerAngles.y, 0f);
		}

		if(Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxis("Vertical") > 0)
		{
			characterModel.rotation  = Quaternion.Euler(0f, camera.rotation.eulerAngles.y + 45f, 0f);
		}
		else if(Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxis("Vertical") < 0)
		{
			characterModel.rotation  = Quaternion.Euler(0f, camera.rotation.eulerAngles.y + 135f, 0f);
		}
		else if(Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxis("Vertical") > 0)
		{
			characterModel.rotation  = Quaternion.Euler(0f, camera.rotation.eulerAngles.y - 45f, 0f);
		}
		else if(Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)
		{
			characterModel.rotation  = Quaternion.Euler(0f, camera.rotation.eulerAngles.y - 135f, 0f);
		}

		if(Input.GetButtonDown("Fire1"))
		{
			characterModel.rotation  = Quaternion.Euler(0f, camera.rotation.eulerAngles.y, 0f);
		}
	}

	// handle player collisions
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		//Debug.Log("Hit " + hit.gameObject.name);

		if(hit.gameObject.tag == "Water")
		{
			Debug.Log("Player died");
			
			Vector3 p = new Vector3(0.0f, 50.0f, 0.0f);

			Vector3 respawnLocation = respawnManager.GetComponent<RespawnManager>().respawnPosition;

			Vector3 displacement = respawnLocation - transform.position + new Vector3(0, 5, 0);

			controller.isTrigger = true;
			controller.Move(displacement);
			controller.isTrigger = false;



			Debug.Log(transform.position);
		}
	}


}















