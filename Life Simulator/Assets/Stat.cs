using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat {

	[SerializeField]
	BarScript bar;

	float maxVal = 100;
	float currentVal = 100;

	[SerializeField]
	float rate = 0.02f;

	public float MaxVal
	{
		get{
			return maxVal;
		}
		set{
			this.maxVal = value;
			bar.MaxValue = maxVal;
		}
	}

	public float CurrentVal
	{
		get{
			return currentVal;
		}
		set{
			this.currentVal = Mathf.Clamp(value, 0, MaxVal);
			bar.Value = currentVal;
		}
	}

	public float Rate { 
		get{
			return rate;
		}
		set{
			this.Rate = rate;
		}
	}

	public void Initialize()
	{
		this.MaxVal = maxVal;
		this.CurrentVal = currentVal;
	}
}
