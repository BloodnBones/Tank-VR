using UnityEngine;
using System.Collections;

public class rotateTank : MonoBehaviour {
     public GameObject tankBody;
     public GameObject tankTurret;
     public GameObject tankBarrell;
     //public GameObject tankTurret;
     //public GameObject tankBarrell;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
    //===============================ROTATE TANK BODY==============================
    if(Input.GetKey("left"))
    {
            tankBody.transform.Rotate(Vector3.up * Time.deltaTime * 80.0f);
    }
    if(Input.GetKey("right"))
    {
            tankBody.transform.Rotate(Vector3.down * Time.deltaTime * 80.0f);
    }
    //=============================ROTATE TANK TURRET=============================
    if(Input.GetKey(KeyCode.D))
    {
            tankTurret.transform.Rotate(Vector3.up * Time.deltaTime * 80.0f);
    }
    if(Input.GetKey(KeyCode.A))
    {
            tankTurret.transform.Rotate(Vector3.down * Time.deltaTime * 80.0f);
    }
    //=============================ROTATE TANK BARRELL=============================
    if(Input.GetKey(KeyCode.W))
    {
            tankBarrell.transform.Rotate(Vector3.left * Time.deltaTime * 80.0f);
    }
    if(Input.GetKey(KeyCode.S))
    {
            tankBarrell.transform.Rotate(Vector3.right * Time.deltaTime * 80.0f);
    }
	}
}
