using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3Start : MonoBehaviour {

    public Boss03 Boss3;
    public Sav sav;
    public Transform duck;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        sav = GameObject.Find("Save").GetComponent<Sav>();
        duck = GameObject.Find("Duck").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.CompareTag("Player"))
        {
            Boss3.start = true;
            sav.CheckPoint = true;
            gameObject.SetActive(false);

        }

    }
}
