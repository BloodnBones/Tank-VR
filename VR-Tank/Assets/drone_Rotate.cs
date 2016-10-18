using UnityEngine;
using System.Collections;

public class drone_Rotate : MonoBehaviour
{


    GameObject target;
    DroneDeath dead;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        dead = transform.parent.gameObject.GetComponent<DroneDeath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead.isDead)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 50)
            {
                Quaternion targetRotation = Quaternion.LookRotation((target.transform.position - transform.position), transform.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
                //Debug.DrawLine(transform.position, transform.forward, Color.blue, 0.1f);
                if (!GetComponent<AudioSource>().isPlaying)
                {
                    GetComponent<AudioSource>().Play();
                }

            }
            else
            {
                GetComponent<AudioSource>().Pause();
            }
        }

    }
}
