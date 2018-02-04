using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1Start : MonoBehaviour {

    public Boss01 Boss1;
    public Sav sav;
    public Transform duck;

    // Use this for initialization
    void Start () {
        
    
    }
	
	// Update is called once per frame
	void Update () {
        sav = GameObject.Find("Save").GetComponent<Sav>();
        duck = GameObject.Find("Duck").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        

        if (col.CompareTag("Player"))
        {
            Boss1.start = true;
            sav.CheckPoint = true;
            gameObject.SetActive(false);
            
        }
        
     }
}
