using UnityEngine;
using System.Collections;

public class navigator : MonoBehaviour
{

    public GameObject target;
    NavMeshAgent agent;
    bool targetSet = false;
    // Use this for initialization
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Hard")
        {
            target = FindClosestEnemy();
        }
        else if (!targetSet)
        {
            if (GameObject.Find("TowerTHING"))
            {
                target = GameObject.Find("TowerTHING");
            }
            targetSet = true;
        }
        if (Vector3.Distance(transform.position, target.transform.position) < 30 || target == null)
        {
            agent.Stop();
        }
        else
        {
            agent.SetDestination(target.transform.position);
        }
    }

    GameObject FindClosestEnemy()
    {
        Debug.Log("looking");
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}

