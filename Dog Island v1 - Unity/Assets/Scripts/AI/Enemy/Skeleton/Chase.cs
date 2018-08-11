using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

	public Transform player;
	public Transform head;
	static Animator anim;
	bool chasing = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
			Vector3 direction = player.position - this.transform.position;//Direction from player to skeleton
			direction.y = 0;
			float angle = Vector3.Angle(direction,head.transform.up);//Angle between skeleton head and player
		if(Vector3.Distance(player.position, this.transform.position)<=10 && (angle<30||chasing)){//If player is within 10 units from skeleton && if angle between player and skeletons head < 30
		chasing = true;
		//Rotation:
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);//Rotate to line up with direction vector 
		
		//Movement:
		anim.SetBool("isIdle",false);
		if(direction.magnitude > 3){//If more than x units away
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
			this.transform.Translate(0,0,0.1f);
            }else{
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);
			}
		}else{
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
			chasing = false;
        }
	}
}
