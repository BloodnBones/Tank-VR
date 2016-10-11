using UnityEngine;
using System.Collections;

public class rotateTank : MonoBehaviour
{
    // public GameObject tankBody;
    public GameObject tankTurret;
    public GameObject tankBarrell;
    public GameObject missileLaunchers;
    public GameObject Camera;
    public Component CameraComp;
    public GameObject Tank;
    public GameObject OVR;



    public bool VR = true;

    //public Animator Firing;

    float mouseX;

    public float rotSpeed;
    public Quaternion Target;
    public Quaternion Target1;


    public GameObject xRot;
    public GameObject yRot;
    // Use this for initialization
    void Start()
    {
        CameraComp = Camera.GetComponent<Camera>();
        //Firing = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraComp = Camera.GetComponent<Camera>();

        //=============================ROTATE TANK TURRET=============================
        if(VR == false)
        {
            Quaternion newAngle = new Quaternion();
            newAngle.eulerAngles = new Vector3(xRot.transform.rotation.eulerAngles.x, yRot.transform.rotation.eulerAngles.y, 0.0f);
            OVR.transform.rotation = newAngle;
        }
        if (VR)
        {
            Vector3 tankRotation = Tank.transform.rotation.eulerAngles;
            tankTurret.transform.localRotation = Quaternion.Euler(0, CameraComp.transform.rotation.eulerAngles.y - tankRotation.y, 0);
        }else
        {
            if (Input.mousePosition.x != mouseX)
            {
                float RotX = (Input.mousePosition.x - mouseX) * 5.0f * Time.deltaTime;
                tankTurret.transform.Rotate(0, RotX, 0);
            }
        }

        //=============================ROTATE TANK BARRELL=============================

        if (VR)
        {
            float h = tankBarrell.transform.rotation.eulerAngles.x - CameraComp.transform.rotation.eulerAngles.x;
            //print(CameraComp.transform.rotation.eulerAngles.x);
            if (CameraComp.transform.rotation.eulerAngles.x > 10 && CameraComp.transform.rotation.eulerAngles.x < 335)
            {
                h = 0;
            }
            //float z = missileLaunchers.transform.rotation.eulerAngles.x - CameraComp.transform.rotation.eulerAngles.x;
            tankBarrell.transform.Rotate(Vector3.left, h);
            missileLaunchers.transform.Rotate(Vector3.left, h);
        }else
        {
            float h = 0.2f * Input.GetAxis("Pitch");
            tankBarrell.transform.Rotate(Vector3.left, h);
            //missileLaunchers.transform.Rotate(Vector3.left, h / 3);
        }
    }

    void LateUpdate()
    {
        mouseX = Input.mousePosition.x;
        
    }
}