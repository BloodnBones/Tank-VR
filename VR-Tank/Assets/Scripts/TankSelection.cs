using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankSelection : MonoBehaviour
{

    private List<GameObject> Models;
    public List<Text> buttons;
    private int selectedTank = 0;
    public int selectedButton = 0;
    GameObject selection;

    // Use this for initialization
    void Start()
    {
        Models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            Models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        Models[selectedTank].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        sceneSelection();
        foreach (GameObject t in Models)
        {
            t.transform.Rotate(new Vector3(0.0f, 30.0f * Time.deltaTime, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<AudioSource>().Play();
            if (selectedTank == 0)
            {
                Models[selectedTank].SetActive(false);
                selectedTank = Models.Count - 1;
                Models[selectedTank].SetActive(true);
            }
            else
            {
                Models[selectedTank].SetActive(false);
                selectedTank--;
                Models[selectedTank].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<AudioSource>().Play();
            if (selectedTank == Models.Count - 1)
            {
                Models[selectedTank].SetActive(false);
                selectedTank = 0;
                Models[selectedTank].SetActive(true);
            }
            else
            {
                Models[selectedTank].SetActive(false);
                selectedTank++;
                Models[selectedTank].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<AudioSource>().Play();
            selection = GameObject.Find("ImortemJoe");
            if (selection != null)
            {
                selection.GetComponent<Inheritance>().SetTank(selectedTank);
            }
            if (selectedButton == 0)
            {
                SceneManager.LoadScene("TestZone");
            }
            else if (selectedButton == 1)
            {
                SceneManager.LoadScene("Skybox");
            }

        }
    }

    void sceneSelection()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

            GetComponent<AudioSource>().Play();
            if (selectedButton > 0)
            {
                selectedButton--;
            }
          
            foreach (Text b in buttons)
            {
                b.color = Color.white;
               
                if (b == buttons[selectedButton])
                {
                  
                    b.color = Color.red;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            GetComponent<AudioSource>().Play();
            if (selectedButton < (buttons.Count - 1))
            {
                selectedButton++;
            }

            foreach (Text b in buttons)
            {
                b.color = Color.white;

                if (b == buttons[selectedButton])
                {
                   
                    if (b == buttons[selectedButton])
                    {
                        b.color = Color.red;
                    }
                }
            }
        }


    }
}
