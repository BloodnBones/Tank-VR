using UnityEngine;
using System.Collections;

public class DroneDeath : MonoBehaviour
{

    public bool isDead = false;
    public int index = 0;
    Flock Ai;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            GetComponent<Rigidbody>().velocity -= new Vector3(0.0f,10.0f,0f);
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().mass += (9f * Time.time);
          
        }

    }
}
