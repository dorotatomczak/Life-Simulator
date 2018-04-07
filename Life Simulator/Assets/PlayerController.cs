using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	private Animator mAnimator;
	private NavMeshAgent mNavMeshAgent;
	bool walking; //potem sie przyda do zmiany animacji

	void Start()
	{
		mAnimator = GetComponent<Animator> ();
		mNavMeshAgent = GetComponent<NavMeshAgent> ();
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
			walking = false;
		} else {
			walking = true;
		}
	}
}
