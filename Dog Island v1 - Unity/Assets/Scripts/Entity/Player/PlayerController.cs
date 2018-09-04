using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	public Image healthBar;

	public int health = 100;
	public int totalHealth = 100;


	public GameObject respawnManager;

	//public Canvas playerRespawnCanvas;


	private bool controlsKilled = false;
	
	/////////////////////////////////////////////////////////////////////////////////////
    //Jethro's powerup code
	public int damage;
    public int healthBoost = 10;
    public int damageBoost = 10;
    public int jumpBoost = 10;

    public float stateTime = 7f;
    float timer;

    bool damageBoosted = false;
    bool jumpBoosted = false;
    bool invincibleBoosted = false;
    /////////////////////////////////////////////////////////////////////////////////////



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
		healthBar.fillAmount = (float) health / (float)totalHealth;

		if(controller.isGrounded)
		{
			controlsKilled = false;
		}

		Movement();
		
		// handle animations
		anim.SetBool("isGrounded", controller.isGrounded);
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")));
		
		/////////////////////////////////////////////////////////////////////////////////////
        //Jethro's powerup code
		if(damageBoosted||invincibleBoosted||jumpBoosted){
            timer += Time.deltaTime;
            if (timer > stateTime)
            {
				//Timer is done
				if(damageBoosted){
					damage-=damageBoost;
					damageBoosted = false;
				}
                if (jumpBoosted)
                {
					jumpForce-=jumpBoost;
					jumpBoosted=false;
                }
                if (invincibleBoosted)
                {
					invincibleBoosted = false;
                }
                timer = 0f;
            }
        }
    
        /////////////////////////////////////////////////////////////////////////////////////

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

		//if(Input.GetButtonDown("Fire1"))
		//{
		//	characterModel.rotation  = Quaternion.Euler(0f, camera.rotation.eulerAngles.y, 0f);
		//}
	}

	// handle player collisions
	//
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.name != "Plane")
		{
			//Debug.Log("Hit: " + hit.gameObject.name);
		}

		if(hit.gameObject.tag == "Water")
		{
			Debug.Log("Player died");
			
			health = 0;


			Debug.Log(transform.position);
		}

		if(health <= 0)
		{
			respawnPlayer();
		}
	}

	void respawnPlayer()
	{
		controlsKilled = true;
		//playerRespawnCanvas.enabled = true;

		Vector3 respawnLocation = respawnManager.GetComponent<RespawnManager>().respawnPosition;

		Vector3 displacement1 = respawnLocation - transform.position;
		displacement1.y = 0;
		Vector3 displacement2 = respawnLocation - transform.position + new Vector3(0, 10, 0);
		displacement2.x = 0;
		displacement2.z = 0;

			//controller.isTrigger = true;
		gameObject.layer = 12;	// uncollidable layer
		controller.Move(displacement1);
		controller.Move(displacement2);
		gameObject.layer = 8;

		health = totalHealth;

		Debug.Log(transform.position);
	}

	public void FaceForward()
	{
		characterModel.rotation  = Quaternion.Euler(0f, camera.rotation.eulerAngles.y, 0f);
	}

	public void LoseHealth(int damage)
	{
		health -= damage;
		/////////////////////////////////////////////////////////////////////////////////////
        //Jethro's powerup code
		if(invincibleBoosted)health+=damage;
        /////////////////////////////////////////////////////////////////////////////////////


		if(health <= 0)
		{
			health = 0;
			//respawnPlayer();
		}
	}

/////////////////////////////////////////////////////////////////////////////////////
    //Jethro's powerup code

    public void BoostHealth()
    {
        if (health <= 90)
        {
            health += healthBoost;
        }
    }

    public void BoostJump()
    {

        jumpForce+=jumpBoost;
    }

    public void BoostDamage()
    {
        if (health <= 90)
        {
            health += healthBoost;
        }
    }

    public void BoostInvincible()
    {
        if (health <= 90)
        {
            health += healthBoost;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////

}















