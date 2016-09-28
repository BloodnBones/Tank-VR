using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour
{

    float LefTrackValue;
    float RightTrackValue;

    private Rigidbody m_rigidbody;

    public float m_speed = 10.0f;

    // Use this for initialization
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        LefTrackValue = Input.GetAxis("LeftTrack");
        RightTrackValue = Input.GetAxis("RightTrack");

        string[] controllers = Input.GetJoystickNames();

        if (gameObject.tag == "LeftTrack")
        {
            //Debug.Log("Update");
            LeftMove();
        }
        if (gameObject.tag == "RightTrack")
        {
            RightMove();
        }
        //int keyCode = 350;
        //for ( int i = 0; i < 60; i++) {

        //    // Log any key press
        //    if (Input.GetKeyDown(keyCode + i)) Debug.Log("Pressed! Joystick " + joyNum + " Button " + buttonNum + " @ " + Time.time);

        //    buttonNum++; // Increment

        //    // Reset button count when we get to last joy button
        //    if (buttonNum == 20)
        //    {
        //        buttonNum = 0;
        //        joyNum++; // next joystick
        //    }
        //}

        Debug.Log(controllers[0]);

    }

    void LeftMove()
    {
        Vector3 movement = transform.forward * LefTrackValue * m_speed * Time.deltaTime;

        m_rigidbody.MovePosition(m_rigidbody.position + movement);

        //Debug.Log("Left");
    }

    void RightMove()
    {
        Vector3 movement = transform.forward * RightTrackValue * m_speed * Time.deltaTime;

        m_rigidbody.MovePosition(m_rigidbody.position + movement);

        //Debug.Log("Right");
    }

}
