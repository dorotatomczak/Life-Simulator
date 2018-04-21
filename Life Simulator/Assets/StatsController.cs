using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour {

    public static bool refillingEnergyBar;
    public static bool refillingHungerBar;

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
        refillingEnergyBar = false;
        refillingHungerBar = false;
    }

	void Update () {
        hunger.ChangeCurrentValue(ref refillingHungerBar, 6.0f);

		bladder.CurrentVal -= bladder.Rate * Time.deltaTime;

        energy.ChangeCurrentValue(ref refillingEnergyBar, 4.0f);

        social.CurrentVal -= social.Rate * Time.deltaTime;
		hygiene.CurrentVal -= hygiene.Rate * Time.deltaTime;
		fun.CurrentVal -= fun.Rate * Time.deltaTime;
	}

    public static void RefillEnergyBar() {
        refillingEnergyBar = true;
    }

    public static void RefillHungerBar() {
        refillingHungerBar = true;
    }
}
