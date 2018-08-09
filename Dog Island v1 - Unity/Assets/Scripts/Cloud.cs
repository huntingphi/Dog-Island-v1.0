using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	public GameObject cloudOne, cloudTwo, cloudThree, cloudFour, cloudFive;
	public GameObject island;
	public int numberOfClouds;


	// Use this for initialization
	void Start () {
		GenerateClouds ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// generate a sky of clouds
	void GenerateClouds() {
		for (int i = 0; i < numberOfClouds; i++) {
			int cloudType = Random.Range (0, 4);

			switch (cloudType) {
				
			case 0:
				{
					break;
				}

			case 1:
				{
					break;
				}

			case 2:
				{
					break;
				}

			case 3:
				{
					break;
				}

			case 4:
				{
					break;
				}
			}

		}
	}
}
