using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	private Animator mAnimator;
	private NavMeshAgent mNavMeshAgent;

	Vector3 targetPosition;
	Vector3 lookAtTarget;
	Quaternion playerRot;
	float rotSpeed = 3;
	bool isWalking;

	void Start()
	{
		mAnimator = GetComponent<Animator> ();
		mNavMeshAgent = GetComponent<NavMeshAgent> ();
		isWalking = false;
	}

	void Update()
	{
		if (Input.GetMouseButton (0)) {
			SetTargetPosition ();
		}
		if (isWalking) {
			Move ();
		}
	}

	void SetTargetPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 20)) {
			targetPosition = hit.point;
			lookAtTarget = new Vector3 (targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
			playerRot = Quaternion.LookRotation (lookAtTarget);
			mNavMeshAgent.destination = targetPosition;
			isWalking = true;
		}
	}


	void Move()
	{
		transform.rotation = Quaternion.Slerp (transform.rotation, playerRot, rotSpeed * Time.deltaTime);

		if ( Vector3.Distance ( transform.position , targetPosition ) < 1) {
			isWalking = false;
		}

		mAnimator.SetBool ("isWalking", isWalking);
	}
    public static void Eat()
    {
        StatsController.RefillHungerBar();
    }
}