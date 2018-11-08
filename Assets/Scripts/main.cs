using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour {

    public bool paused;

    public void restart()
    {
    	//Application.LoadLevel(Application.loadedLevel);
    	 paused = false;
    	 Time.timeScale = 1;
    	 SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Application.Quit();
    }

	// Use this for initialization
	void Start () {
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
