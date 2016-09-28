using UnityEngine;
using System.Collections;

public class HeightStabilizer : MonoBehaviour {

	public WheelCollider[] wheels;

	public float springSTR;
	public float springDMP;

	public HoverControl hcs;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//--------------------- Hover Height Adjustment Sector ------------------------//

		//springSTR = 800 + (hcs.velocity * hcs.magStrength * Time.deltaTime);
		//springDMP = 20 + (hcs.velocity * hcs.magStrength * Time.deltaTime);

		//foreach (WheelCollider wheel in wheels) {
			//JointSpring suspensionSpring = new JointSpring ();
			//suspensionSpring.spring = springSTR;          
			//suspensionSpring.damper = springDMP;          
			//suspensionSpring.targetPosition = 0.25F;
			//wheel.GetComponent<WheelCollider> ().suspensionSpring = suspensionSpring;
		//}	

	}
}
