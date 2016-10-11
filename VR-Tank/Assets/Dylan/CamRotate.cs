using UnityEngine;
using System.Collections;

public class CamRotate : MonoBehaviour {
  
    public bool Active;
    // Use this for initialization
    void Start () {
        Active = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Active)
        {
           
        }
        //Debug.Log("xRot:" + xRot.transform.rotation.x + " yRot:" + yRot.transform.rotation.y + " transform.rotation.eulerAngles:" + transform.rotation.eulerAngles);
    }
}
