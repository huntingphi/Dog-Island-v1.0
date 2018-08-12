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

	/*
	 * methods
	 */

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			GameObject tempBullet;
			tempBullet = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

			Rigidbody bulletRigidbody;
			bulletRigidbody = tempBullet.GetComponent<Rigidbody>();
			bulletRigidbody.AddForce(transform.forward * bulletForce);

			Destroy(tempBullet, 10.0f);

		}	
	}
}
