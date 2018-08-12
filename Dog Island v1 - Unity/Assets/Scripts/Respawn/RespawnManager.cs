using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour 
{

	/*
	 * instances
	 */

	public Vector3 respawnPosition;



	 /*
	 * methods
	 */


	void Start () 
	{
		
	}
	

	void Update () 
	{
		
	}

	public void updateRespawnPosition(Vector3 position)
	{
		respawnPosition = position;
	}

	public void respawnPlayer(Transform playerTransform)
	{
		playerTransform.position = respawnPosition;
	}
}
