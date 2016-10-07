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
       // rockets.Initialise();

        tankRigidBody.centerOfMass = com;
        tankRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        float RightMove = Input.GetAxis("Vertical");
        float LeftMove = Input.GetAxis("Horizontal");

        powerInput = RightMove + LeftMove;
        turnInput = -RightMove + LeftMove;
        tankRigidBody.AddRelativeForce(0f, 0f, powerInput * speed);
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