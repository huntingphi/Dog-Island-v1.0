using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HurtPlayer(int damage)
	{
		currentHealth -= damage;
	}

	public void HealPlayer(int healzies)
	{
		currentHealth += healzies;

		if(currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
	}
}
