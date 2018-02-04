using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControll : MonoBehaviour {

    public GameObject PauseUI;
    public bool Paused;

    // Use this for initialization
    void Start () {
        Paused = false;
        PauseUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            Paused = !Paused;
        }

        if (Paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        Paused = false;
    }
}
