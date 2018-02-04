using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LifeControll : MonoBehaviour {

    public DuckController duck;
    public Image life;
    public Image life1;
    public Image life2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(duck.Life == 3)
        {
            life.color = new Color(255, 255, 255, 255);
            life1.color = new Color(255, 255, 255, 255);
            life2.color = new Color(255, 255, 255, 255);
        }else if (duck.Life == 2)
        {
            life.color = new Color(255, 255, 255, 255);
            life1.color = new Color(255, 255, 255, 255);
            life2.color = new Color(0f, 0f, 0f, 255);
        }
        else if (duck.Life == 1)
        {
            life.color = new Color(255, 255, 255, 255);
            life1.color = new Color(0f, 0f, 0f, 255);
            life2.color = new Color(0f, 0f, 0f, 255);
        }
        else if (duck.Life <= 0)
        {
            life.color = new Color(0f, 0f, 0f, 255);
            life1.color = new Color(0f, 0f, 0f, 255);
            life2.color = new Color(0f, 0f, 0f, 255);
        }
    }
}
