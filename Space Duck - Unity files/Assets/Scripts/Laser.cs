using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public Vector2 speed;
    public Rigidbody2D LaserR;
    public Transform Fox;
    public DuckController duck;

    // Use this for initialization
    void Start()
    {
        LaserR = GetComponent<Rigidbody2D>();
        Fox = GameObject.Find("Boss03").GetComponent<Transform>();
        duck = GameObject.Find("Duck").GetComponent<DuckController>();

        if (Fox.localScale.x > 0)
        {
            LaserR.velocity = speed * -1;
            Destroy(this.gameObject, 10f);


        }
        else if (Fox.localScale.x < 0)
        {
            LaserR.velocity = speed;
            Destroy(this.gameObject, 10f);
            gameObject.GetComponent<Transform>().localScale = this.gameObject.GetComponent<Transform>().localScale * -1;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            duck.Life -= 1;

            duck.knockbackCount = 1;
            Destroy(this.gameObject);

            if (LaserR.transform.position.x > duck.DuckRigi.position.x)
            {
                duck.KnockDir = true;
            }
            else if (LaserR.transform.position.x < duck.DuckRigi.position.x)
            {
                duck.KnockDir = false;
            }
        }

    }
}
