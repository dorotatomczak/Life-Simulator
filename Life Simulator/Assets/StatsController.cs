using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour {

	[SerializeField]
	Stat hunger;

	[SerializeField]
	Stat bladder;

	[SerializeField]
	Stat energy;

	[SerializeField]
	Stat social;

	[SerializeField]
	Stat hygiene;

	[SerializeField]
	Stat fun;

	void Awake () {
		hunger.Initialize ();
		bladder.Initialize ();
		energy.Initialize ();
		social.Initialize ();
		hygiene.Initialize ();
		fun.Initialize ();
	}

	void Update () {
		hunger.CurrentVal -= hunger.Rate * Time.deltaTime;
		bladder.CurrentVal -= bladder.Rate * Time.deltaTime;
		energy.CurrentVal -= energy.Rate * Time.deltaTime;
		social.CurrentVal -= social.Rate * Time.deltaTime;
		hygiene.CurrentVal -= hygiene.Rate * Time.deltaTime;
		fun.CurrentVal -= fun.Rate * Time.deltaTime;
	}
}
