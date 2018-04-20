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
        if (!refillingHungerBar)
            hunger.CurrentVal -= hunger.Rate * Time.deltaTime;
        else {
            hunger.CurrentVal += 6.0f * Time.deltaTime;
            if (hunger.CurrentVal >= 100)
            {
                hunger.CurrentVal = 100;
                refillingHungerBar = false;
            }
        }

		bladder.CurrentVal -= bladder.Rate * Time.deltaTime;

        if(!refillingEnergyBar)
		    energy.CurrentVal -= energy.Rate * Time.deltaTime;
        else {
            energy.CurrentVal += 3.0f * Time.deltaTime;
            if(energy.CurrentVal >= 100) {
                energy.CurrentVal = 100;
                refillingEnergyBar = false;
            }
        }
		social.CurrentVal -= social.Rate * Time.deltaTime;
		hygiene.CurrentVal -= hygiene.Rate * Time.deltaTime;
		fun.CurrentVal -= fun.Rate * Time.deltaTime;
	}
    public static void RefillEnergyBar() {
        refillingEnergyBar = true;
    }
    public static void RefillHungerBar()
    {
        refillingHungerBar = true;
    }
}
