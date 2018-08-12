using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour 
{
	/*
	 * instances
	 */
	public Transform stationLocation;
	public GameObject respawnManager;


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
			respawnManager.GetComponent<RespawnManager>().updateRespawnPosition(stationLocation.position);
		}
	}

	//void notifyRespawnManager(Vector3 position)
	//{

	//}
}
