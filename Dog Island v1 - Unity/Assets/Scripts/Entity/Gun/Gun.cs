using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{
	/*
	 * instances
	 */
	public GameObject bulletEmitter;
	public GameObject bullet;
	public float bulletForce;
	GameObject player;

	/*
	 * methods
	 */

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			player.GetComponent<PlayerController>().FaceForward();
			GameObject tempBullet;
			tempBullet = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

			Rigidbody bulletRigidbody;
			bulletRigidbody = tempBullet.GetComponent<Rigidbody>();
			bulletRigidbody.AddForce(transform.forward * bulletForce);

			Destroy(tempBullet, 10.0f);

		}	
	}
}
