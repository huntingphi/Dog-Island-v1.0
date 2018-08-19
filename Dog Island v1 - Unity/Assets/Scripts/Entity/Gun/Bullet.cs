﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{

	/*
	 * instances
	 */
	public int damage = 10;

	public GameObject bulletDestructEffect;




	/*
	 * methods
	 */

	void Start () 
	{
		
	}
	
	
	void Update () 
	{

	}

	void OnCollisionEnter(Collision other) 
	{
		Debug.Log("Hit " + other.gameObject.name);
        EnemyHealth destroyableObject = other.transform.GetComponent<EnemyHealth>();
        if(destroyableObject != null)
		{
			// if object is hit, subtract bullet damage from the object's health
			destroyableObject.LoseHealth(damage);
		}

		var effect = Instantiate(bulletDestructEffect, gameObject.transform.position,  Quaternion.identity);
		Destroy(effect , 2.0f);
		Destroy(gameObject);
    }

}








