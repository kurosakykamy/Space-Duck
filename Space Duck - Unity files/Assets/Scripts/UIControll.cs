using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControll : MonoBehaviour {

    
    public string RetryLV;
    public string NextLV;
    public GameObject Save;


    // Use this for initialization
    void Start () {
        
        

       
    }
	
	// Update is called once per frame
	void Update () {
        Save = GameObject.Find("Save");

        RetryLV = Save.GetComponent<Sav>().LV;
        
        if(RetryLV == "lv2")
        {
            NextLV = "lv1";
        }else if (RetryLV == "lv1")
        {
            NextLV = "lv3";
        }



    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Retry()
    {
        //Destroy(GameObject.Find("Save"));
        SceneManager.LoadScene(RetryLV);
    }

    public void Next()
    {

        SceneManager.LoadScene(NextLV);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("lv2");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {

        SceneManager.LoadScene(PlayerPrefs.GetString("continue"));
    }

}
