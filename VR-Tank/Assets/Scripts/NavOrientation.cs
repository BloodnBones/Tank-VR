using UnityEngine;
using System.Collections;

public class NavOrientation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
      //  Debug.DrawRay(transform.position, Vector3.down);
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
           
        }
	}
}
