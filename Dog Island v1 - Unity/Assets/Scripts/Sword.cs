using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour 
{
	public int damage = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) 
	{
		Debug.Log(other.gameObject.name);

        PlayerController player = other.transform.GetComponent<PlayerController>();

        if(player != null)
		{
			// if object is hit, subtract bullet damage from the object's health
			player.LoseHealth(damage);
		}

		//var effect = Instantiate(bulletDestructEffect, gameObject.transform.position,  Quaternion.identity);
		//Destroy(effect , 2.0f);

	}
}
