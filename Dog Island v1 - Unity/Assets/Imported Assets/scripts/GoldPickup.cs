using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour {

	public GameObject pickupEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			FindObjectOfType<GameManager>().AddGold(10);

			Instantiate(pickupEffect, transform.position, transform.rotation);

			Destroy(gameObject);
		}
	}
}
