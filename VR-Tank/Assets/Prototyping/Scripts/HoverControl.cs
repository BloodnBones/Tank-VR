using UnityEngine;
using System.Collections;

public class HoverControl : MonoBehaviour
{

    public float velocity;                  //Movement strength
    public float agility;                   //Turning strength

    public Rigidbody rb;
    public Vector3 com;                     //Centre of Mass
    public Transform centerax;              //Camera controller
    public Transform accelerator;           //Direction of motion
    public GameObject tankTurret;

    public WheelCollider[] wheels;

    private float fl_down = 0f;
    private float fr_down = 0f;
    private float bl_down = 0f;
    private float br_down = 0f;

    public WheelCollider fl;
    public WheelCollider fr;
    public WheelCollider ml;
    public WheelCollider mr;
    public WheelCollider bl;
    public WheelCollider br;

    public GameObject vehicleMesh;

    void Start()
    {
        rb.centerOfMass = com;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        fl.motorTorque = 0;
        fr.motorTorque = 0;
        bl.motorTorque = 0;
        br.motorTorque = 0;
        ml.motorTorque = 0;
        mr.motorTorque = 0;

        if (Input.GetAxis("Vertical") > 0)
        {
            fr.motorTorque = 50.0f;
            br.motorTorque = 50.0f;
            mr.motorTorque = 50.0f;
            //  rb.velocity += (accelerator.transform.position - rb.transform.position).normalized * velocity * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            fr.motorTorque = -50.0f;
            br.motorTorque = -50.0f;
            mr.motorTorque = -50.0f;
            //  rb.velocity -= (accelerator.transform.position - rb.transform.position).normalized * velocity * Time.deltaTime;
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            fl.motorTorque = 50.0f;
            bl.motorTorque = 50.0f;
            ml.motorTorque = 50.0f;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            fl.motorTorque = -50.0f;
            bl.motorTorque = -50.0f;
            ml.motorTorque = -50.0f;
        }

        
       

        //if (Input.GetKey(KeyCode.D))
        //{
        //    tankTurret.transform.Rotate(Vector3.up * Time.deltaTime * 80.0f);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    tankTurret.transform.Rotate(Vector3.down * Time.deltaTime * 80.0f);
        //}

        //aTurnSpeed = -Input.GetAxis ("Horizontal") * (agility * 40);
        //vehicleMesh.transform.localEulerAngles = new Vector3 (0, 0, (Mathf.Clamp(aTurnSpeed, -30f, 30f)))
    }

}