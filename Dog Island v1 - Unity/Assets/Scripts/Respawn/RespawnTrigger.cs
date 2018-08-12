using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour 
{
	/*
	 * instances
	 */


	/*
	 * methods
	 */

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			Debug.Log("We got a player");
		}
	}
}
