using UnityEngine;
using System.Collections;

public class SteeringSystem : MonoBehaviour
{

    public GameObject target;
    public GameObject leader;
    public float moveSpeed = 1.0f;
    public float rotationSpeed = 1.0f;

    int minDistance = 1;
    int safeDistance = 60;

    static float t = 0.0f;
    float maxy = 0.05f;
    float miny = -0.05f;

    //steer stuff
    Vector3 velocity;
    Vector3 acceleration;
    float maxforce;
    float circleRad = 5;
    float WanderAngle = 40;
    float angleChange = 60;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.gameObject.tag == "Leader")
        {
            arrival(target.transform.position);
        }
        else
        {
            follow(leader.transform.position,
                leader.GetComponent<SteeringSystem>().velocity);
        }
     
        velocity = velocity + acceleration;
        limit(velocity, moveSpeed);
        transform.position += velocity * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), rotationSpeed * Time.deltaTime);
        acceleration *= 0;

        transform.position += new Vector3(0, Mathf.Lerp(miny, maxy, t), 0) * Time.deltaTime;

        t += 0.5f * Time.deltaTime;


        if (t > 1.0f)
        {
            float temp = maxy;
            maxy = miny;
            miny = temp;
            t = 0.0f;
        }


    }
    void seek(Vector3 target)
    {
        Vector3 desired = target - transform.position;

        if (desired.x != 0 || desired.z != 0)
        {
            desired = desired.normalized * moveSpeed;
        }

        Vector3 steer = desired - velocity;

        // Limit the magnitude of the steering force.
        limit(steer, maxforce);

        applyForce(steer);
    }

    void limit(Vector3 vec, float maxLength)
    {
        float lengthSquared = vec.x * vec.x + vec.y * vec.y + vec.z * vec.z;

        if ((lengthSquared > maxLength * maxLength) && (lengthSquared > 0))
        {
            float ratio = maxLength / Mathf.Sqrt(lengthSquared);
            vec.x *= ratio;
            vec.y *= ratio;
            vec.z *= ratio;
        }
    }

    void applyForce(Vector3 force)
    {
        acceleration += force;
    }

    void arrival(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        float distance = desired.magnitude;
        float slowRad = 15;

        if (desired.x != 0 || desired.z != 0)
        {
            if (distance < slowRad)
            {
                desired = desired.normalized * moveSpeed * (distance / slowRad);
            }
            else
            {
                desired = desired.normalized * moveSpeed;
            }
        }

        Vector3 steer = desired - velocity;
        applyForce(steer);

    }

    void flee(Vector3 target)
    {
        Vector3 desired = target - transform.position;

        if (desired.x != 0 || desired.z != 0)
        {
            desired = desired.normalized * moveSpeed;
        }

        Vector3 Evade_desired = -1.0f * desired;
        Vector3 steer = Evade_desired - velocity;

        // Limit the magnitude of the steering force.
        limit(steer, maxforce);
        applyForce(steer);
    }

    void pursuit(Vector3 target, Vector3 targetVelocity)
    {

        Vector3 distance = target - transform.position;
        float Scalar = distance.magnitude / 0.8f;

        Vector3 futurePos = target + targetVelocity * Scalar;

        seek(futurePos);
    }

    void evade(Vector3 target, Vector3 targetVelocity)
    {

        Vector3 distance = target - transform.position;
        float Scalar = distance.magnitude / 0.8f;

        Vector3 futurePos = target + targetVelocity * Scalar;

        flee(futurePos);
    }
    void SetAngle(Vector3 vector, float angle)
    {
        float length = vector.magnitude;
        vector.x = Mathf.Cos(angle) * length;
        vector.z = Mathf.Sin(angle) * length;
    }
    void wander()
    {
        int Randompos = Random.Range(0, 100);
        int Rand = Random.Range(0, 1);

        if (Randompos < 10)
        {
            Vector3 circle;
            circle = velocity;

            if (circle.x != 0 || circle.z != 0)
            {
                circle = circle.normalized * circleRad;
            }

            Vector3 displacement = new Vector3(0, 0, -1) * circleRad;

            SetAngle(displacement, WanderAngle);

            WanderAngle += Rand * angleChange - angleChange * 0.5f;

            Vector3 wanderForce = circle + displacement;
            limit(wanderForce, 0.1f);
            applyForce(wanderForce);
        }
    }

    void separation()
    {
        Vector3 steer = new Vector3();
        int neighbours = 0;
        float sepRad = 50;

        //Check if other enemy nearby
        foreach (Transform other in transform.parent)
        {
            if (other != transform)
            {
                Vector3 otherPos = other.position;

                if (otherPos != transform.position && Vector3.Distance(otherPos, transform.position) < sepRad)
                {
                    steer += new Vector3((otherPos.x - transform.position.x), 0, (otherPos.z - transform.position.z));
                    neighbours++;
                }
            }
        }

        if (neighbours != 0)
        {
            steer.x /= neighbours;
            steer.z /= neighbours;

            steer *= -1.0f;
        }

        if (steer.x != 0 || steer.z != 0)
        {
            steer = steer.normalized;
        }

        applyForce(steer);
    }

    void allignment()
    {
        Vector3 steer = new Vector3();
        int neighbours = 0;
        float radius = 200;

        foreach (Transform other in transform.parent)
        {
            if (other != transform)
            {
                Vector3 otherPos = other.position;

                if (otherPos != transform.position && Vector3.Distance(otherPos, transform.position) < radius)
                {
                    steer += new Vector3(other.gameObject.GetComponent<SteeringSystem>().velocity.x, 0,
                        other.gameObject.GetComponent<SteeringSystem>().velocity.z);
                    neighbours++;
                }
            }
        }

        if (neighbours != 0)
        {
            steer.x /= neighbours;
            steer.z /= neighbours;
        }

        if (steer.x != 0 || steer.z != 0)
        {
            steer = steer.normalized;
        }

        applyForce(steer);
    }


    void cohesion()
    {
        Vector3 steer = new Vector3();
        int neighbours = 0;
        float radius = 30;

        foreach (Transform other in transform.parent)
        {
            if (other != transform)
            {
                Vector3 otherPos = other.position;

                if (otherPos != transform.position && Vector3.Distance(otherPos, transform.position) < radius)
                {     
                    steer.x += otherPos.x;
                    steer.z += otherPos.z;
                    neighbours++;
                }
            }
        }

        if (neighbours != 0)
        {
            steer.x /= neighbours;
            steer.z /= neighbours;
            steer -= transform.position;
        }

        if (steer.x != 0 || steer.z != 0)
        {
            steer = steer.normalized;
        }

        applyForce(steer);
    }

    void follow(Vector3 target, Vector3 targetVelocity)
    {
        float leaderDist = 10;
        float leaderSightDist = 20;

        Vector3 ahead = new Vector3();
        //Ahead point
        if (targetVelocity.x != 0 || targetVelocity.z != 0) //check if velocity is 0
        {
            ahead = target + (targetVelocity.normalized * leaderDist);
        }
        else
        {
            ahead = new Vector3(target.x + leaderDist, target.y + leaderDist, target.z + leaderDist);
        }


        //Behind point
        Vector3 behind = target + (targetVelocity * -1.0f);

        //if enemy is in leader's sight
        if ((Vector3.Distance(ahead, transform.position) <= leaderSightDist) || (Vector3.Distance(target, transform.position) <= leaderSightDist))
        {
            evade(target, targetVelocity);
        }

        //Create arrival force to behind point
        arrival(behind);

        //Apply seperation force
        separation();
    }

}
