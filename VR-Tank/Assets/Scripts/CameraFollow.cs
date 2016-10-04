using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public float rotationSpeed;


    public GameObject _Tank;
    public GameObject _Camera;

    Component _CameraComp;

    Quaternion angles;

    private Vector3 vPos;
    //private Vector3 oPos;
    private Quaternion rPos;

    float v;
    float h;

    float CamY;
    float CamX;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _CameraComp = _Camera.GetComponent<Camera>();
        //oPos = target.localPosition;
    }

    void FixedUpdate()
    {
        
        angles = InputTracking.GetLocalRotation(VRNode.CenterEye);
        //print("X: " + angles.eulerAngles.x + "  Y: " + angles.eulerAngles.y + "  Z: " + angles.eulerAngles.z);
        if (angles.eulerAngles.x != CamX)
        {
            float RotY = (angles.eulerAngles.x - CamX) * rotationSpeed * Time.deltaTime;
            this.transform.Rotate(0, RotY, 0);
        }

        if (angles.eulerAngles.y != CamY)
        {
            float RotX = (CamY - angles.eulerAngles.y) * rotationSpeed * Time.deltaTime;
            _Camera.transform.Rotate(RotX, 0, 0);
        }

        //_Camera.transform.forward = _Tank.transform.forward;

        // v += 2.0f * Input.GetAxis("Roll");
        //Camera.transform.Rotate(Vector3.up, v);

        // h += 0.8f * Input.GetAxis("Pitch");
        //Camera.transform.Rotate(Vector3.left, h);


        //  _Camera.transform.LookAt(new Vector3(v, h, 0));

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //tor3.MoveTowards (hcs.centerax.transform.localPosition.x, oPos, Time.deltaTime * returnSpeed);
    }

    void LateUpdate()
    {
        CamY = angles.eulerAngles.y;
        CamX = angles.eulerAngles.x;
    }
}

