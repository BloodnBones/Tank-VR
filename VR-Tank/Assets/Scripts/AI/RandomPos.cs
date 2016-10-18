using UnityEngine;
using System.Collections;

public class RandomPos : MonoBehaviour {

    float RandomX;
    float RandomZ;
    Vector3 oldPos;
    Vector3 newPos;
    bool canChange = false;
	// Use this for initialization
	void Start () {
        StartCoroutine("ChangePosition");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(canChange)
        {
            StartCoroutine("ChangePosition");
        }  
	}

    IEnumerator ChangePosition()
    {
        canChange = false;
        yield return new WaitForSeconds(5.0f);
        oldPos = transform.position;
        RandomX = Random.Range(oldPos.x, Random.Range(oldPos.x + 40 , oldPos.x - 40));
        RandomZ = Random.Range(oldPos.z, Random.Range(oldPos.z + 40, oldPos.z - 40));
        if (RandomX > 20)
        {
            RandomX = 0;
        }
        else if(RandomX < -90){
            RandomX = 0;
        }
        if(RandomZ > 50)
        {
            RandomZ = 0;
        }
        else if (RandomZ < -10)
        {
            RandomZ = 0;
        }
        newPos = new Vector3(RandomX, oldPos.y, RandomZ);
        transform.position = newPos;

        canChange = true;

    }


}
