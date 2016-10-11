using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankController : MonoBehaviour {

    public List<GameObject> Tanks;

    int TanktoUse;
	// Use this for initialization
	void Start () {
        foreach(Transform t in transform)
        {
            Tanks.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        if (GameObject.Find("ImortemJoe"))
        {
            TanktoUse = GameObject.Find("ImortemJoe").GetComponent<Inheritance>().GetTank();
        }
        else
        {
            TanktoUse = 2;
        }

        Tanks[TanktoUse].SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
