﻿using UnityEngine;
using System.Collections;

public class Flock : MonoBehaviour {

    private GameObject Controller;
    private bool inited = false;
    private float minVelocity;
    private float maxVelocity;
    private float randomness;
    private GameObject chasee;

    void Start()
    {
        StartCoroutine("Steering");
    }

    IEnumerator Steering()
    {
        while (true)
        {
            if (inited)
            {
                GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + Calc() * Time.deltaTime;

                // enforce minimum and maximum speeds for the boids
                float speed = GetComponent<Rigidbody>().velocity.magnitude;
                if (speed > maxVelocity)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxVelocity;
                }
                else if (speed < minVelocity)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * minVelocity;
                }
            }

            float waitTime = Random.Range(0.3f, 0.5f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private Vector3 Calc()
    {
        Vector3 randomize = new Vector3((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1);

        randomize.Normalize();
        AdvancedSteering FlockController = Controller.GetComponent<AdvancedSteering>();
        Vector3 flockCenter = FlockController.flockCenter;
        Vector3 flockVelocity = FlockController.flockVelocity;
        Vector3 follow = chasee.transform.localPosition;

        flockCenter = flockCenter - transform.localPosition;
        flockVelocity = flockVelocity - GetComponent<Rigidbody>().velocity;
        follow = follow - transform.localPosition;

        return (flockCenter + flockVelocity + follow * 2 + randomize * randomness);
    }

    public void SetController(GameObject theController)
    {
        Controller = theController;
        AdvancedSteering FlockController = Controller.GetComponent<AdvancedSteering>();
        minVelocity = FlockController.minVelocity;
        maxVelocity = FlockController.maxVelocity;
        randomness = FlockController.randomness;
        chasee = FlockController.chasee;
        inited = true;
    }
}
//=======
//﻿using UnityEngine;
//using System.Collections;

//public class Flock : MonoBehaviour {

//    private GameObject Controller;
//    private bool inited = false;
//    private float minVelocity;
//    private float maxVelocity;
//    private float randomness;
//    private GameObject chasee;
//    private Drone_Shoot FireAi;
//    void Start()
//    {
//        StartCoroutine("Steering");
//        FireAi = gameObject.GetComponent<Drone_Shoot>();
//    }

//    IEnumerator Steering()
//    {
//        while (true)
//        {
//            if (inited)
//            {
                
//                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + Calc() * Time.deltaTime;

//                    // enforce minimum and maximum speeds for the boids
//                    float speed = GetComponent<Rigidbody>().velocity.magnitude;
//                    if (speed > maxVelocity)
//                    {
//                        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxVelocity;
//                    }
//                    else if (speed < minVelocity)
//                    {
//                        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * minVelocity;
//                    }
                
//            }

//            float waitTime = Random.Range(0.3f, 0.5f);
//            yield return new WaitForSeconds(waitTime);
//        }
//    }

//    private Vector3 Calc()
//    {
//        Vector3 randomize = new Vector3((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1);

//        randomize.Normalize();
//        AdvancedSteering FlockController = Controller.GetComponent<AdvancedSteering>();
//        Vector3 flockCenter = FlockController.flockCenter;
//        Vector3 flockVelocity = FlockController.flockVelocity;
//        Vector3 follow = chasee.transform.localPosition;

//        flockCenter = flockCenter - transform.localPosition;
//        flockVelocity = flockVelocity - GetComponent<Rigidbody>().velocity;
//        follow = follow - transform.localPosition;

//        return (flockCenter + flockVelocity + follow * 2 + randomize * randomness);
//    }

//    public void SetController(GameObject theController)
//    {
//        Controller = theController;
//        AdvancedSteering FlockController = Controller.GetComponent<AdvancedSteering>();
//        minVelocity = FlockController.minVelocity;
//        maxVelocity = FlockController.maxVelocity;
//        randomness = FlockController.randomness;
//        chasee = FlockController.chasee;
//        inited = true;
//    }
//}
//>>>>>>> Stashed changes
