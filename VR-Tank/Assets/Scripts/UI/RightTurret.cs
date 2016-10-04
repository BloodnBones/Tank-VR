using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class RightTurret
{

	public BarControl bar;
	public float maxVal;
	public float currentVal;

	public float CurrentVal
	{
		get
		{
			return currentVal;
		}

		set
		{
			this.currentVal = Mathf.Clamp(value, 0, maxVal);
			bar.Value = currentVal;
		}
	}
	public float MaxVal
	{
		get
		{
			return maxVal;
		}

		set
		{
			this.maxVal = value;
			bar.MaxValue = maxVal;
		}
	}

	public void Initialise()
	{
		this.MaxVal = maxVal;
		this.CurrentVal = currentVal;
	}

}