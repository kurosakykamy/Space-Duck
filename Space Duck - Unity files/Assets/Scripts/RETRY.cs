using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RETRY : MonoBehaviour {

    public string RetryLV;
    public GameObject Save;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Save = GameObject.Find("Save");

        RetryLV = Save.GetComponent<Sav>().LV;
        if (Input.GetButtonDown("Attack"))
        {
            SceneManager.LoadScene(RetryLV);
        }
    }
}
