using UnityEngine;
using System.Collections;

public class BuggyEMP : MonoBehaviour {


    public bool empGo = false;
    bool instatiate = false;
    public GameObject empParticle;
    public ShootAi gun1;
    public ShootAi gun2;
    public Buggy_Rotate rotation;
    public int duration = 5;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (empGo)
        {
            StopEverything();
        }

    }

    void StopEverything()
    {
        if (!instatiate)
        {
            StartCoroutine("stopEMP");
            empParticle = Instantiate(empParticle, transform.position, empParticle.transform.rotation) as GameObject;
            instatiate = true;
        }
        GetComponent<NavMeshAgent>().Stop();
        GetComponent<navigator>().enabled = false;
        rotation.enabled = false;
        gun1.enabled = false;
        gun2.enabled = false;
    }

    IEnumerator stopEMP()
    {
        yield return new WaitForSeconds(duration);
        empGo = false;
        GetComponent<navigator>().enabled = true;
        rotation.enabled = true;
        gun1.enabled = true;
        gun2.enabled = false;
        empParticle = null;
    }
}