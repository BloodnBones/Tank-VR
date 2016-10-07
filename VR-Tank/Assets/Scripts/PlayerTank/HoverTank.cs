using UnityEngine;
using System.Collections;

public class ThrusterScript : MonoBehaviour
{

    public float thrusterStrength;
    public float thrusterDistance;
    public Transform[] thrusters;

    public Rigidbody rigidbody;

   // public HoverController hc;

    // Use this for initialization
    void FixedUpdate()
    {

        RaycastHit hit;
        foreach (Transform thruster in thrusters)
        {
            Vector3 downwardForce;
            float distancePercentage;

            if (Physics.Raycast(thruster.position, thruster.up * -1, out hit, (thrusterDistance * 2f)))
            {
                distancePercentage = 1 - (hit.distance - (hit.distance / thrusterDistance));

                downwardForce = transform.up * thrusterStrength * distancePercentage;
                downwardForce = downwardForce * Time.deltaTime * rigidbody.mass;

                rigidbody.AddForceAtPosition(downwardForce, thruster.position);

                if (distancePercentage > 0.3)
                {
                    //rigidbody.AddForceAtPosition ((downwardForce/10), rigidbody.transform.up);

                    //Debug.Log ("Max Distance!");
                }

                // adam wrote this
                //var groundPosY = hit.point.y + thrusterDistance;
                //var clampedY = Mathf.Clamp( rigidbody.position.y, hit.point.y, groundPosY );
                //rigidbody.position = new Vector3(rigidbody.position.x, clampedY, rigidbody.position.z);


                Debug.DrawLine(thruster.position, hit.point, Color.red);
                Debug.DrawRay(Vector3.zero, new Vector3(1, 0, 0), Color.red);
            }
        }

    }
}