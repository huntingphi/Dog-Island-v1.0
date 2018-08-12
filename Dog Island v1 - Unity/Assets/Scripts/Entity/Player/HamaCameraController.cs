using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamaCameraController : MonoBehaviour {

		/*
	 * instances
	 */
	/*public float rotateSpeed;
	public float vertical;
	public Transform cameraTarget;
	public Vector3 cameraDistance;*/

	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;

	GameObject character;

	// Use this for initialization
	void Start () 
	{
		/*cameraDistance = new Vector3(0, -5, 10);
		*/
		//Cursor.lockState = CursorLockMode.Locked;

		character = this.transform.parent.gameObject;

		transform.LookAt(character.transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{

		var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1.0f / smoothing);
		smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1.0f / smoothing);
		mouseLook += smoothV;
		mouseLook.y = Mathf.Clamp(mouseLook.y, -70.0f, 70.0f);

		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);


	}
}
