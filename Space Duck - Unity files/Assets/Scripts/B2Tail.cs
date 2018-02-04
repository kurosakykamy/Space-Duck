using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2Tail : MonoBehaviour
{

    public int Life;
    public Rigidbody2D Tail;
    public DuckController duck;
    public Boss02 boss;
    public float timer;
    public float dx;

    // Use this for initialization
    void Start()
    {
        Life = 1;
        duck = GameObject.Find("Duck").GetComponent<DuckController>();
        boss = GameObject.Find("Boss 2").GetComponent<Boss02>();
        dx = GameObject.Find("Duck").GetComponent<Transform>().position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Tail.transform.position = new Vector3(dx, -10.5f, 0);

        timer += Time.deltaTime;
        if(timer > 2.2)
        {
            Destroy(this.gameObject);
        }

        if(Life == 0)
        {
            boss.Life--;
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            duck.Life -= 1;

            duck.knockbackCount = 1;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            if (Tail.transform.position.x > duck.DuckRigi.position.x)
            {
                duck.KnockDir = true;
            }
            else if (Tail.transform.position.x < duck.DuckRigi.position.x)
            {
                duck.KnockDir = false;
            }
        }
        if (col.CompareTag("Attk"))
        {
            Life -= 1;

        }
    }
}
