using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemyHealth : MonoBehaviour 
{
	/*
	 * instances
	 */
	 public Image healthBar;

	 public int health;
	 public int totalHealth;

	

	/*
	 * methods
	 */
	void Start () 
	{
		
	}
	
	
	void Update () 
	{
		healthBar.fillAmount = (float) health / totalHealth;
	}

	public void LoseHealth(int amount)
	{
		health -= amount;

		if(health <= 0)
		{
			//Destroy(gameObject);
		}
	}
}
