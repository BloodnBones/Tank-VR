using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class TankTurretAndCam : MonoBehaviour
{
    // public GameObject tankBody;
    public GameObject tankTurret;
    public GameObject tankBarrell;
    public GameObject missileLaunchers;
    public GameObject Camera;
    public Component CameraComp;
    public GameObject Tank;
    public GameObject OVR;

    Quaternion angles;

    float CamY;
    float CamX;


    public bool VRMode = true;

    //public Animator Firing;

    float mouseX;
    float mouseY;

    public float rotSpeed;
    //public Quaternion Target;
    //public Quaternion Target1;

    // Use this for initialization
    void Start()
    {
        CameraComp = Camera.GetComponent<Camera>();
        //Firing = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        angles = InputTracking.GetLocalRotation(VRNode.CenterEye);
        //CameraComp = Camera.GetComponent<Camera>();

        //=============================CAMERA TANK CONTROLS=============================
        //=============================CAMERA TANK CONTROLS=============================
        //=============================CAMERA TANK CONTROLS=============================
        if (VRMode)
        {
            //=============================ROTATE TANK TURRET=============================
            //=============================ROTATE TANK TURRET=============================
            //=============================ROTATE TANK TURRET=============================
            Vector3 tankRotation = Tank.transform.rotation.eulerAngles;
            tankTurret.transform.localRotation = Quaternion.Euler(0, CameraComp.transform.rotation.eulerAngles.y - tankRotation.y, 0);

            //=============================ROTATE TANK BARRELL============================
            //=============================ROTATE TANK BARRELL============================
            //=============================ROTATE TANK BARRELL============================
            float h = tankBarrell.transform.rotation.eulerAngles.x - CameraComp.transform.rotation.eulerAngles.x;
            
            if (CameraComp.transform.rotation.eulerAngles.x > 10 && CameraComp.transform.rotation.eulerAngles.x < 335)
            {
                h = 0;
            }
            //float z = missileLaunchers.transform.rotation.eulerAngles.x - CameraComp.transform.rotation.eulerAngles.x;
            tankBarrell.transform.Rotate(Vector3.left, h);
            //missileLaunchers.transform.Rotate(Vector3.left, h);
        }
        else
        {
            //=============================ROTATE TANK TURRET=============================
            //=============================ROTATE TANK TURRET=============================
            //=============================ROTATE TANK TURRET=============================


            if (Input.mousePosition.x != mouseX)
            {
                float RotY = (Input.mousePosition.x - mouseX);// * 5.0f * Time.deltaTime;
                tankTurret.transform.Rotate(0, RotY, 0);
                //Debug.Log("Rotating turret!");
            }
            //=============================ROTATE TANK BARRELL============================
            //=============================ROTATE TANK BARRELL============================
            //=============================ROTATE TANK BARRELL============================       


            if (Input.mousePosition.y != mouseY)
            {
                float RotX = (mouseY - Input.mousePosition.y);// * 5.0f * Time.deltaTime;
                tankBarrell.transform.Rotate(RotX, 0, 0);
                //Debug.Log("Rotating Barrell!");
            }
            //=============================ROTATE CAMERA=============================
            //=============================ROTATE CAMERA=============================
            //=============================ROTATE CAMERA=============================
            if (angles.eulerAngles.x != CamX)
            {
                float RotY = (angles.eulerAngles.x - CamX);// * 4.0f * Time.deltaTime;
                Camera.transform.Rotate(0, RotY, 0);
            }
            if (angles.eulerAngles.y != CamY)
            {
                float RotX = (CamY - angles.eulerAngles.y);// * rotationSpeed * Time.deltaTime;
                Camera.transform.Rotate(RotX, 0, 0);
            }
            //Quaternion newAngle = new Quaternion();
            //newAngle.eulerAngles = new Vector3(tankBarrell.transform.rotation.eulerAngles.x, tankTurret.transform.rotation.eulerAngles.y, 0.0f);
            //OVR.transform.rotation = newAngle;
        }
    }

    void LateUpdate()
    {
        CamY = angles.eulerAngles.y;
        CamX = angles.eulerAngles.x;
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
    }
}