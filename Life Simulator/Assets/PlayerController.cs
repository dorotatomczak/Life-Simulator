using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	private Animator mAnimator;
	private NavMeshAgent mNavMeshAgent;
	bool isWalking;

	void Start()
	{
		mAnimator = GetComponent<Animator> ();
		mNavMeshAgent = GetComponent<NavMeshAgent> ();
		isWalking = false;
	}

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;

		if (Input.GetMouseButtonDown (0)) 
		{
			if (Physics.Raycast (ray, out hit, 100)) {
				mNavMeshAgent.destination = hit.point;
			}
		}

		if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance) {
			isWalking = false;
		} else {
			isWalking = true;
		}

		mAnimator.SetBool ("isWalking", isWalking);
	}
}
