using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

	public Transform canvas;

    public bool restart = false;
    public bool menu = false;
    public bool quit = false;

	
	// Update is called once per frame
	void Update () 
	{
        
        if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Pause();
		}
		if (canvas.gameObject.activeInHierarchy == true) 
		{
			if (Input.GetKeyDown (KeyCode.R) || restart) 
			{
				SceneManager.LoadScene("TestZone");
			}
			if (Input.GetKeyDown (KeyCode.M) || menu) 
			{
				SceneManager.LoadScene("MainMenu");
			}
			if (Input.GetKeyDown (KeyCode.Q) || quit) 
			{
				Application.Quit();

			}
		}

        restart = false;
        menu = false;
        quit = false;


    }

	public void Pause()
	{
		
		if (canvas.gameObject.activeInHierarchy == false) 
			{
				canvas.gameObject.SetActive (true);
				Time.timeScale = 0;
			} 
			else
			{
				canvas.gameObject.SetActive (false);
				Time.timeScale = 1;
			}

	}

    public void SetRestart()
    {
        restart = true;
    }
    public void SetMenu()
    {
        menu = true;
    }
    public void SetQuit()
    {
        quit = true;
    }



}
