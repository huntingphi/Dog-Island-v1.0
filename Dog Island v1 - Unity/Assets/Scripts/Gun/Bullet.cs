using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{

	/*
	 * instances
	 */
	public int damage = 1;




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
        //Debug.Log("Hit "+ other.gameObject.name);

        Destroyable destroyableObject = other.transform.GetComponent<Destroyable>();
        if(destroyableObject != null)
		{
			// if object is hit, subtract bullet damage from the object's health
			destroyableObject.LoseHealth(damage);
			Destroy(gameObject);
		}
    }

}
