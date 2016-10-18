using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletMove : MonoBehaviour
{
    //Switches
    public bool IsRotation = true;
    static public bool IsGravity = true;
    public bool IsMoveForward = true;
    //Rotation
    public Vector3 dir;
    public Vector3 SeeAhead;
    public Vector3 LastKnowPosition;
    public Vector3 CurrentPosition;
    public Vector3 velocity;
    static public float RotationSpeed = 0.0f;
    public float MaxRotationSpeed = 5.0f;

    public float ACTUALROTATIONSPEED;
    //Gravity

    int counter;

    //float dist;
    //public Transform target;
    //public List<GameObject> rock_planets;
    // Use this for initialization
    void Start()
    {
        counter = 0;
        //Rotation
        CurrentPosition = new Vector3(0.0f, 0.0f, 0.0f);
        SeeAhead = transform.position + velocity.normalized * 2;
        dir = new Vector3(0.0f, 0.0f, 0.0f);
        LastKnowPosition = new Vector3(0.0f, 0.0f, 0.0f);
        
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        if (counter < 6)
        {
            counter += 1;
        }

        //Rotation
        if (IsRotation == true && counter > 5)
        {
            SeeAhead = transform.position + velocity.normalized * 2;

            dir = transform.position - LastKnowPosition;
        
            dir.Normalize();

            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

            ACTUALROTATIONSPEED = Mathf.Clamp(RotationSpeed, 0.0f, MaxRotationSpeed);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, ACTUALROTATIONSPEED);
        }

        //Move forward
        if (IsMoveForward == true)
        {
            Vector3 pos = transform.position;
            velocity = new Vector3(0, 0, 10 * Time.deltaTime);
            pos += transform.rotation * velocity;

            LastKnowPosition = transform.position;

            transform.position = pos;

        }

        CurrentPosition = transform.position;
    }
}
