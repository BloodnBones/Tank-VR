using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarControl : MonoBehaviour {

	[SerializeField]
	private float fillAmount;

	public float lerpSpeed;
	//public StatArmour statArm;

	public Image content;
	public Text valueCounter;

	public float MaxValue { get; set;}
	public float Value
	{
		set
		{ 
			valueCounter.text = value + "";
			fillAmount = Map(value, 0, MaxValue, 0, 1);
		}
	}

	//private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	//{
	//	return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		//return (value / inMax);
	//}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		HandleBar();
		/*
		value = statArm.currentVal/statArm.maxVal;
		if (value >= 1)
		{value = 1;}
		if (value <= 0)
		{value = 0;}
		content.fillAmount = value;
		*/

	}

	private void HandleBar()
	{
		//content.fillAmount = Map(22,0,100,0,1);
		//content.fillAmount = fillAmount;
		//content.fillAmount = fillAmount;
		if (fillAmount != content.fillAmount) 
		{
			//if (fillAmount = 0) 
			//{
			//	content.fillAmount = fillAmount;
			//}
			//if (fillAmount = 1) 
			//{
			//	content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
			//}
			content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		}
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		//Debug.Log ("Completely broken");
		//return (value / inMax);
	}
}
