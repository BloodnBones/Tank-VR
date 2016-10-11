using UnityEngine;
using System.Collections;

public class Inheritance : MonoBehaviour {


    int TankChosen;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetTank(int Choice)
    {
        TankChosen = Choice;
    }

    public int GetTank()
    {
        return TankChosen;
    }
}
