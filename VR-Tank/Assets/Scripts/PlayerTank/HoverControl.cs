using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HoverControl : MonoBehaviour
{

    public float velocity;                  //Movement strength
    public float agility;                   //Turning strength

    public Rigidbody tankRigidBody;
    public Vector3 com;                     //Centre of Mass
    public float maxDistance = 0;
    public float hoverForce = 0;
    public float speed = 90f;
    public float turnSpeed = 5f;

    public WheelCollider[] wheels;

    public WheelCollider fl;
    public WheelCollider fr;
    public WheelCollider ml;
    public WheelCollider mr;
    public WheelCollider bl;
    public WheelCollider br;

    public float Torque;
    float TorqueL;
    float TorqueR;
    float averageHeight;
    Vector3 averageAngle;

    public float powerInput;
    public float turnInput;

    public GameObject vehicleMesh;

    //	----- Armour UI -----	 //
    [SerializeField]
    private StatArmour armour;
    [SerializeField]
    private StatRockets rockets;
	[SerializeField]
	private StatArmour leftTurret;
	[SerializeField]
	private StatRockets rightTurret;

    private void Awake()
    {
      //  armour.Initialise();
        rockets.Initialise();

        tankRigidBody.centerOfMass = com;
        tankRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //==========================================================================================================
        //                                  HOVER HEIGHT CALCULATION
        //----------------------------------------------------------------------------------------------------------
     //   Vector3 tankPosFrontRight = tankRigidBody.transform.position + new Vector3(1.1f, 0.0f, 2.2f);
     //   Vector3 tankPosBackRight = tankRigidBody.transform.position + new Vector3(1.1f, 0.0f, -2.2f);
     //   Vector3 tankPosFrontLeft = tankRigidBody.transform.position + new Vector3(-1.1f, 0.0f, 2.2f);
     //   Vector3 tankPosBackLeft = tankRigidBody.transform.position + new Vector3(-1.1f, 0.0f, -2.2f);

     //   Ray rayFrontRight = new Ray(tankPosFrontRight, new Vector3(0.0f, -1.0f, 0.0f));
     //   Ray rayBackRight = new Ray(tankPosBackRight, new Vector3(0.0f, -1.0f, 0.0f));
     //   Ray rayFrontLeft = new Ray(tankPosFrontLeft, new Vector3(0.0f, -1.0f, 0.0f));
     //   Ray rayBackLeft = new Ray(tankPosBackLeft, new Vector3(0.0f, -1.0f, 0.0f));

     //   RaycastHit hitFrontRight;
     //   RaycastHit hitBackRight;
     //   RaycastHit hitFrontLeft;
     //   RaycastHit hitBackLeft;

     //   Vector3 appliedHFFR = new Vector3(0, 0, 0);
     //   Vector3 appliedHFBR = new Vector3(0, 0, 0);
     //   Vector3 appliedHFFL = new Vector3(0, 0, 0);
     //   Vector3 appliedHFBL = new Vector3(0, 0, 0);


     //   if ( Physics.Raycast(rayFrontRight, out hitFrontRight, maxDistance))
     //   {
     //       // averageHeight += hitFrontRight.distance;
     //       float proportionalHeight = 1 - (hitFrontRight.distance - (hitFrontRight.distance / maxDistance));
     //       appliedHFFR = Vector3.up * proportionalHeight * hoverForce/* * Time.deltaTime*/;   
     //       averageAngle += hitFrontRight.normal;
     //   }

     //   if (Physics.Raycast(rayBackRight, out hitBackRight, maxDistance))
     //   {
     //       // averageHeight += hitBackRight.distance;
     //       float proportionalHeight = 1 - (hitBackRight.distance - (hitBackRight.distance / maxDistance));//(maxDistance - hitBackRight.distance) / maxDistance;
     //       appliedHFBR = Vector3.up * proportionalHeight * hoverForce /** Time.deltaTime*/;

     //       averageAngle += hitBackRight.normal; }

     //   if (Physics.Raycast(rayFrontLeft, out hitFrontLeft, maxDistance))
     //   {
     //       //averageHeight += hitFrontLeft.distance;
     //       float proportionalHeight = 1 - (hitFrontLeft.distance - (hitFrontLeft.distance / maxDistance));
     //       appliedHFFL = Vector3.up * proportionalHeight * hoverForce /** Time.deltaTime*/;
     //       averageAngle += hitFrontLeft.normal;
     //   }

     //   if (Physics.Raycast(rayBackLeft, out hitBackLeft, maxDistance))
     //   {
     //       //  averageHeight += hitBackLeft.distance;
     //       float proportionalHeight = 1 - (hitBackLeft.distance - (hitBackLeft.distance / maxDistance));
     //       appliedHFBL = Vector3.up * proportionalHeight * hoverForce /** Time.deltaTime*/;
           
     //       averageAngle += hitBackRight.normal;
     //   }

        
     //// tankRigidBody.AddForceAtPosition()

     // //  averageHeight /= 4;
     //   averageAngle /= 4;

     //   tankRigidBody.AddForceAtPosition(appliedHFFR, tankPosFrontRight, ForceMode.Acceleration);
     //   tankRigidBody.AddForceAtPosition(appliedHFBR, tankPosBackRight, ForceMode.Acceleration);
     //   tankRigidBody.AddForceAtPosition(appliedHFFL, tankPosFrontLeft, ForceMode.Acceleration);
     //   tankRigidBody.AddForceAtPosition(appliedHFBL, tankPosBackLeft, ForceMode.Acceleration);

        //float proportionalHeight = (maxDistance - averageHeight) / maxDistance;
        //Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
        //tankRigidBody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        //------------------------------------------------------------------------------------------------------------------


        float RightMove = Input.GetAxis("Vertical");
        float LeftMove = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Vertical") != 0)
        {
            TorqueR = Torque;
        }
        else
        {
            TorqueR = 0;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            TorqueL = Torque;
        }
        else
        {
            TorqueL = 0;
        }

        powerInput = RightMove + LeftMove;
        turnInput = -RightMove + LeftMove;
        // tankRigidBody.AddRelativeForce(0f, 0f, powerInput * speed);
        tankRigidBody.transform.Rotate(Vector3.up, turnInput * turnSpeed * Time.deltaTime);

        fr.motorTorque = Torque * powerInput;
        br.motorTorque = Torque * powerInput;
        mr.motorTorque = Torque * powerInput;

        fl.motorTorque = Torque * powerInput;
        bl.motorTorque = Torque * powerInput;
        ml.motorTorque = Torque * powerInput;

    }

    void FixedUpdate()
    {
        

        if (Input.GetButtonDown("Fire"))
        {
            rockets.CurrentVal -= 1;
        }
    }

    void OnTriggerStay(Collider other)                  //This is temporary for testing with the damage/heal boxes
    {
        if (other.name == "Debug-Damage")
        {
            armour.CurrentVal -= 1;
        }
        if (other.name == "Debug-Heal")
        {
            armour.CurrentVal += 1;
            rockets.CurrentVal += 1;
        }
    }
}