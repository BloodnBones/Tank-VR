using UnityEngine;
using System.Collections;

public class AI_Rotate : MonoBehaviour {

    public float speed;
    GameObject target;
    public Transform Parent;
    Quaternion NextRotation;
    
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

        target = FindClosestEnemy();
        if (Vector3.Distance(target.transform.position, transform.position) < 70)
        {
            Quaternion looktarget = Quaternion.LookRotation(target.transform.position - transform.position);
            Quaternion targetHorizontal = transform.rotation;

            targetHorizontal.y = looktarget.y;
            targetHorizontal.w = looktarget.w;

            transform.rotation = targetHorizontal;
            Debug.DrawLine(transform.position, transform.parent.forward, Color.blue, 0.1f);
        }
        else
        {
            speed = 0.001f;
            NextRotation = Quaternion.LookRotation(Parent.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, NextRotation, Time.time * speed);
        }

    }

    GameObject FindClosestEnemy()
    {
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
