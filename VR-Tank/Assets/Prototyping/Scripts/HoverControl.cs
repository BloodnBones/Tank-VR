using UnityEngine;
using System.Collections;

public class HoverControl : MonoBehaviour {

	public float velocity;                  //Movement strength
	public float agility;                   //Turning strength

	public Rigidbody rb;
	public Vector3 com;                     //Centre of Mass
	public Transform centerax;              //Camera controller
	public Transform accelerator;           //Direction of motion

	public WheelCollider[] wheels;

	private float fl_down = 0f;
	private float fr_down = 0f;
	private float bl_down = 0f;
	private float br_down = 0f;
	
	public WheelCollider fl;
	public WheelCollider fr;
	public WheelCollider bl;
	public WheelCollider br;

	public GameObject vehicleMesh;

	void Start ()
	{
		rb.centerOfMass = com;
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
        fl.


		if (Input.GetAxis ("Vertical") > 0)
		{
			rb.velocity += (accelerator.transform.position - rb.transform.position).normalized * velocity * Time.deltaTime;
		}
		if (Input.GetAxis ("Vertical") < 0)
		{
			rb.velocity -= (accelerator.transform.position - rb.transform.position).normalized * velocity * Time.deltaTime;
		}


		//aTurnSpeed = -Input.GetAxis ("Horizontal") * (agility * 40);
		//vehicleMesh.transform.localEulerAngles = new Vector3 (0, 0, (Mathf.Clamp(aTurnSpeed, -30f, 30f)));
    }
}

	
