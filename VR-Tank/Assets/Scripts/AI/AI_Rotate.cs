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

        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 30)
            {
                NextRotation = Quaternion.LookRotation(target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, NextRotation, Time.time * speed);
            }
            else
            {
                speed = 0.001f;
                NextRotation = Quaternion.LookRotation(Parent.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, NextRotation, Time.time * speed);
            }
        }
        else
        {
            speed = 0.001f;
            NextRotation = Quaternion.LookRotation(Parent.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, NextRotation, Time.time * speed);
        }

    }
}
