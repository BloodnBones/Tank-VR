using UnityEngine;
using System.Collections;

public class rotateTank : MonoBehaviour {
    // public GameObject tankBody;
    public GameObject tankTurret;
    public GameObject tankBarrell;
    public GameObject missileLaunchers;
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
    //        tankBody.transform.Rotate(Vector3.up * Time.deltaTime * 80.0f);
    }
    if(Input.GetKey("right"))
    {
     //       tankBody.transform.Rotate(Vector3.down * Time.deltaTime * 80.0f);
    }
        //=============================ROTATE TANK TURRET=============================

        float v = 1.0f * Input.GetAxis("Roll");
        tankTurret.transform.Rotate(Vector3.up, v);
        //if(Input.GetKey(KeyCode.D))
        //{
        //        tankTurret.transform.Rotate(Vector3.up * Time.deltaTime * 80.0f);
        //}
        //if(Input.GetKey(KeyCode.A))
        //{
        //        tankTurret.transform.Rotate(Vector3.down * Time.deltaTime * 80.0f);
        //}

        //=============================ROTATE TANK BARRELL=============================

        float h = 0.2f * Input.GetAxis("Pitch");
        tankBarrell.transform.Rotate(Vector3.left, h);
        missileLaunchers.transform.Rotate(Vector3.left, h / 3);
      //  if(tankBarrell.transform.rotation > 5.0f)
    //    if (Input.GetKey(KeyCode.W))
    //{
    //        tankBarrell.transform.Rotate(Vector3.left * Time.deltaTime * 80.0f);
    //}
    //if(Input.GetKey(KeyCode.S))
    //{
    //        tankBarrell.transform.Rotate(Vector3.right * Time.deltaTime * 80.0f);
    //}
	}
}
