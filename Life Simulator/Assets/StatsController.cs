using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StatsController : NetworkBehaviour
{

    public static bool refillingEnergyBar;
    public static bool refillingHungerBar;

    public static float refillingSpeed;

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
        hunger.ChangeCurrentValue(ref refillingHungerBar, refillingSpeed);

		bladder.CurrentVal -= bladder.Rate * Time.deltaTime;

        energy.ChangeCurrentValue(ref refillingEnergyBar, refillingSpeed);

        social.CurrentVal -= social.Rate * Time.deltaTime;
		hygiene.CurrentVal -= hygiene.Rate * Time.deltaTime;
		fun.CurrentVal -= fun.Rate * Time.deltaTime;
	}

    public static void RefillEnergyBar(float speed) {
        refillingEnergyBar = true;
        refillingSpeed = speed;
    }

    public static void RefillHungerBar(float speed) {
        refillingHungerBar = true;
        refillingSpeed = speed;
    }
}
