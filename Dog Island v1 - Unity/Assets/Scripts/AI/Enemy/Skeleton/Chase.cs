using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{

    public Transform player;
    public Transform head;
    Animator animator;

	Animation animation;

    string state = "patrol";
    public GameObject[] waypoints;
    int currentWaypoint;
    float rotationSpeed = 1f;
    float speed = 2f;
    float marginToWaypoint = 5f;
    bool chasing = false;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        // animation = GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;//Direction from player to skeleton
        direction.y = 0;
        float angle = Vector3.Angle(direction, head.transform.up);//Angle between skeleton head and player
		Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"));
        if (state == "patrol" && waypoints.Length > 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);
            animator.SetBool("isAttacking", false);
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")&&Vector3.Distance(waypoints[currentWaypoint].transform.position, this.transform.transform.position) < marginToWaypoint)
            {
					if(currentWaypoint %2 ==0) {
                    Debug.Log(currentWaypoint);
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isIdle", true);
					animator.Play("Idle",0);
					}
                currentWaypoint++;
                if (currentWaypoint >= waypoints.Length)
                {
                    currentWaypoint = 0;
                }
                    // int idle = Random.Range(0,7); // creates a number between 1 and 12
					
            }
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);

            // animator.SetBool("isWalking", false);
            // animator.SetBool("isAttacking", false);
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
            direction = waypoints[currentWaypoint].transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);//Rotate to line up with direction vector 
            this.transform.Translate(0, 0, Time.deltaTime * speed);

			}
        }


        if (Vector3.Distance(player.position, this.transform.position) <= 10 && (angle < 60 || state == "persuing"))
        {//If player is within 10 units from skeleton && if angle between player and skeletons head < 30
            state = "persuing";
            //Rotation:
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);//Rotate to line up with direction vector 

            //Movement:
            // animator.SetBool("isIdle",false);
            if (direction.magnitude > 3)
            {//If more than x units away
                this.transform.Translate(0, 0, speed * Time.deltaTime);
                animator.Play("Walk", 0);
                animator.SetBool("isWalking", true);
                animator.SetBool("isAttacking", false);
            }
            else
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", true);
            }
        }
        else
        {
            // animator.SetBool("isIdle", true);
            // if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            // {

            animator.SetBool("isWalking", true);
            animator.SetBool("isAttacking", false);
            state = "patrol";
			// }

        }
    }
}
