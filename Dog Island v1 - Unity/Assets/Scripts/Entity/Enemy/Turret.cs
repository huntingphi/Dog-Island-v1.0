using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour 
{

	public Transform target;
	public Transform partToRotate;

	public GameObject enemyBulletPrefab;
	public Transform firePoint;

	public int range = 15;

	public int rotateSpeed = 2;

	public float fireRate = 1f;
	private float fireCountDown  = 0f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		Vector3 dir = target.position - partToRotate.transform.position;
		if(dir.magnitude <= range)
		{
			Quaternion lookRotation = Quaternion.LookRotation(dir);
			Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;

			partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

			if(fireCountDown <= 0f)
			{
				Shoot();
				fireCountDown = 1f / fireRate;

			}

			fireCountDown -= Time.deltaTime;
		}

		//Debug.Log("Count down  = " + fireCountDown );

		


	}

	void Shoot()
	{
		Debug.Log("SHOOT");

		Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
	}


}









