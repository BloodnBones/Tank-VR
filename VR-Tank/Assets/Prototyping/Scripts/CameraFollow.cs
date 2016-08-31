using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float upDistance;
	public float backDistance;
	public float trackingSpeed;
	public float rotationSpeed;
	public float returnSpeed;

	public HoverControl hcs;

	private Vector3 vPos;
	//private Vector3 oPos;
	private Quaternion rPos;

	public float lCam;
	public float rCam;

	void Start ()
	{
		//oPos = target.localPosition;
	}

	void FixedUpdate () 
	{
		//float mvSlide = -Input.GetAxis("Horizontal") * (hcs.agility)/4;

		vPos = target.position - target.forward * backDistance + target.up * upDistance;
		transform.position = Vector3.MoveTowards (transform.position, vPos, trackingSpeed * Time.deltaTime);
		//rPos = Quaternion.LookRotation(target.position - transform.position, target.up);
		//transform.rotation = Quaternion.Slerp (transform.rotation, rPos, rotationSpeed * Time.deltaTime * (hcs.agility * 2));

		//hcs.centerax.transform.Translate(new Vector3(Mathf.MoveTowards(-mvSlide, mvSlide, Time.deltaTime), 0, 0));

		if (Input.GetAxis ("Horizontal") != 0) 
		{
			lCam -= 0.03f;
		}
		if (Input.GetAxis ("Horizontal") != 0) 
		{
			rCam += 0.03f;
		}

		//float t = (Time.time - 1)

		lCam += 0.01f;
		rCam -= 0.01f;
		lCam = Mathf.Clamp (lCam, -0.5f, 0f);
		rCam = Mathf.Clamp (rCam, 0f, 0.5f);

		Vector3 tmpPos = hcs.centerax.transform.localPosition;
		tmpPos.x = Mathf.Clamp (tmpPos.x, lCam, rCam);
		hcs.centerax.transform.localPosition = tmpPos;

		//hcs.centerax.transform.Translate(new Vector3(Mathf.MoveTowards(0, 0, Time.deltaTime), 0, 0));

		//hcs.centerax.transform.localPosition = Vector3.MoveTowards (hcs.centerax.transform.localPosition.x, oPos, Time.deltaTime * returnSpeed);
	}
}

