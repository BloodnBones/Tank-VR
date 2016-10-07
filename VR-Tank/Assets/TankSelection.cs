using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TankSelection : MonoBehaviour {

    private List<GameObject> Models;
    private int selectedTank = 0;

	// Use this for initialization
	void Start () {
        Models = new List<GameObject>();
        foreach(Transform t in transform)
        {
            Models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        Models[selectedTank].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        Models[selectedTank].transform.Rotate(new Vector3(0.0f, 30.0f * Time.deltaTime, 0.0f));
	if(Input.GetKeyDown(KeyCode.A))
        {
            if(selectedTank > 0)
            {
                Models[selectedTank].SetActive(false);
                selectedTank--;
                Models[selectedTank].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (selectedTank < Models.Count - 1)
            {
                Models[selectedTank].SetActive(false);
                selectedTank++;
                Models[selectedTank].SetActive(true);
            }
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            GameObject.Find("ImortemJoe").GetComponent<Inheritance>().SetTank(selectedTank);
            SceneManager.LoadScene("TestZone");

        }
    }
}
