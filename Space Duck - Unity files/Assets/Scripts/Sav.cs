using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sav : MonoBehaviour {

    public Transform duck;
    public Scene Scene1;
    public Scene Scene2;
    public string LV;
    public string LV2;
    public bool CheckPoint;

    // Use this for initialization
    void Start () {

        
        Scene1 = SceneManager.GetActiveScene();
        LV = Scene1.name;

    }
	
	// Update is called once per frame
	void Update () {

        if (LV == "lv2" && LV2 == "lv1")
        {
            Destroy(this.gameObject);
        }
        else if (LV == "lv1" && LV2 == "lv3")
        {
            Destroy(this.gameObject);
        }
        if ((LV == "lv1" && LV2 == "lv2"))
        {
            Destroy(this.gameObject);
        }
        if ((LV == "lv3" && LV2 == "lv1"))
        {
            Destroy(this.gameObject);
        }
        if ((LV == "lv3" && LV2 == "lv2"))
        {
            Destroy(this.gameObject);
        }
        if ((LV == "lv2" && LV2 == "lv3"))
        {
            Destroy(this.gameObject);
        }

        Scene2 = SceneManager.GetActiveScene();
        LV2 = Scene2.name;

        duck = GameObject.Find("Duck").GetComponent<Transform>();

        if (CheckPoint && duck.position.x< 475f && LV == "lv1")
        {
            
            duck.position = new Vector3(510.6f, 7.64f, duck.position.z);
        }
        if(CheckPoint && duck.position.x < 550f && LV == "lv2")
            {

            duck.position = new Vector3(565.22f, 2.02f, duck.position.y);
        }
        if (CheckPoint && duck.position.x < 822.07f && LV == "lv3")
        {

            duck.position = new Vector3(826.62f, -16.36f, duck.position.y);
        }


        DontDestroyOnLoad(this.gameObject);

        



       



        if (LV2 == "lv2")
        {
            PlayerPrefs.SetString("continue","lv2");
        }else if (LV2 == "lv1")
        {
            PlayerPrefs.SetString("continue", "lv1");
        }else if (LV2 == "lv3")
        {   
            PlayerPrefs.SetString("continue", "lv3");
        }

    }

}
