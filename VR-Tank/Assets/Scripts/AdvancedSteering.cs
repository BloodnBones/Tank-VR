﻿using UnityEngine;
using System.Collections;

public class AdvancedSteering : MonoBehaviour
{

    public float minVelocity = 5;
    public float maxVelocity = 20;
    public float randomness = 1;
    public int flockSize = 10;
    public GameObject prefab;
    public GameObject chasee;

    public Vector3 flockCenter;
    public Vector3 flockVelocity;

    private GameObject[] Drones;

    void Start()
    {
        chasee = GameObject.FindGameObjectWithTag("Player");
        Drones = new GameObject[flockSize];
        for (var i = 0; i < flockSize; i++)
        {
            Vector3 position = new Vector3(
                Random.value * GetComponent<Collider>().bounds.size.x,
               // Random.value * GetComponent<Collider>().bounds.size.y,
               transform.position.y,
                Random.value * GetComponent<Collider>().bounds.size.z
            ) - GetComponent<Collider>().bounds.extents;

            GameObject _Drone = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
            _Drone.transform.parent = transform;
            _Drone.transform.localPosition = position;
            _Drone.GetComponent<Flock>().SetController(gameObject);
            _Drone.GetComponent<DroneDeath>().setIndex(i);
            Drones[i] = _Drone;
        }
    }

    void Update()
    {
        Vector3 theCenter = Vector3.zero;
        Vector3 theVelocity = Vector3.zero;

        foreach (GameObject Agent in Drones)
        {
            if (Agent != null)
            {
                if (Agent.GetComponent<DroneDeath>().isDead)
                {
                    Drones[Agent.GetComponent<DroneDeath>().index] = null;
                }
                theCenter = theCenter + Agent.transform.localPosition;
                theVelocity = theVelocity + Agent.GetComponent<Rigidbody>().velocity;
            }
        }

        flockCenter = theCenter / (flockSize);
        flockVelocity = theVelocity / (flockSize);
    }
}
//=======
//﻿using UnityEngine;
//using System.Collections;

//public class AdvancedSteering : MonoBehaviour {

//    public float minVelocity = 5;
//    public float maxVelocity = 20;
//    public float randomness = 1;
//    public int flockSize = 10;
//    public GameObject prefab;
//    public GameObject chasee;

//    public Vector3 flockCenter;
//    public Vector3 flockVelocity;

//    private GameObject[] Drones;

//    void Start()
//    {
//        Drones = new GameObject[flockSize];
//        for (var i = 0; i < flockSize; i++)
//        {
//            Vector3 position = new Vector3(
//                Random.value * GetComponent<Collider>().bounds.size.x,
//               // Random.value * GetComponent<Collider>().bounds.size.y,
//               transform.position.y,
//                Random.value * GetComponent<Collider>().bounds.size.z
//            ) - GetComponent<Collider>().bounds.extents;

//            GameObject _Drone = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
//            _Drone.transform.parent = transform;
//            _Drone.transform.localPosition = position;
//            _Drone.GetComponent<Flock>().SetController(gameObject);
//            Drones[i] = _Drone;
//        }
//    }

//    void Update()
//    {
//        Vector3 theCenter = Vector3.zero;
//        Vector3 theVelocity = Vector3.zero;

//        foreach (GameObject Agent in Drones)
//        {
//            theCenter = theCenter + Agent.transform.localPosition;
//            theVelocity = theVelocity + Agent.GetComponent<Rigidbody>().velocity;
//        }

//        flockCenter = theCenter / (flockSize);
//        flockVelocity = theVelocity / (flockSize);
//    }
//>>>>>>> Stashed changes
//}