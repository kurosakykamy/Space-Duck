using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBall : MonoBehaviour {

    public Rigidbody2D AcidRigid;
    public DuckController duck;
    public float dx;
    public Transform acidB;
    public bool dir;

    // Use this for initialization
    void Start () {

        AcidRigid = GetComponent<Rigidbody2D>();
        duck = GameObject.Find("Duck").GetComponent<DuckController>();
        dx = GameObject.Find("Duck").GetComponent<Transform>().position.x;
        

    }

	// Update is called once per frame
	void Update () {

        AcidRigid.position = Vector3.MoveTowards(AcidRigid.position, new Vector3(dx, -11f, 0), Time.deltaTime*8.5f);

        if(acidB.position.x < dx && !dir)
        {
            acidB.localScale = new Vector2(acidB.localScale.x * -1, acidB.localScale.y);
            dir = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Player"))
        {

            duck.Life -= 1;

            duck.knockbackCount = 1;
            Destroy(this.gameObject);

            if (AcidRigid.transform.position.x > duck.DuckRigi.position.x)
            {
                duck.KnockDir = true;
            }
            else if (AcidRigid.transform.position.x < duck.DuckRigi.position.x)
            {
                duck.KnockDir = false;
            }
        }
        if (col.CompareTag("ground"))
        {
            Destroy(this.gameObject);
        }

    }
}
