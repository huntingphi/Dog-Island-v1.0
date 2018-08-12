using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableEntity : MonoBehaviour 
{

	/*
	 * instances
	 */
	public int health = 1;


	void Start () 
	{
		
	}
	
	/*
	 * methods
	 */

	void Update () 
	{
		
	}


	// decrements the entity's health when it gets hit by a bullet
	public void LoseHealth(int amount)
	{
		health -= amount;

		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
