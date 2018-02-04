using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour {

    public DuckController duck;
    public Rigidbody2D Rigid;
    public Transform GroundCheck;
    public Transform WallCheck;
    public LayerMask IsGround;
    public float Vel;
    public bool Dir;
    public int Life;

    private bool InGround;
    private bool InWall;
    private float GroundRadius = 0.2f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if(Life <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    void FixedUpdate () {
        MobMove();
        
    }

    void MobMove()
    {

        InGround = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, IsGround);
        InWall = Physics2D.OverlapCircle(WallCheck.position, GroundRadius, IsGround);

        if (!InGround || InWall)
        {
            Rigid.transform.localScale = new Vector2(-Rigid.transform.localScale.x, Rigid.transform.localScale.y);
            Dir = !Dir;
        }
        if (InGround && !Dir)
        {
            
            Rigid.velocity = new Vector2(Vel, Rigid.velocity.y);
            
        }
        if (InGround && Dir)
        {

            Rigid.velocity = new Vector2(-Vel, Rigid.velocity.y);
            

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Attk"))
        {
            Life -= 1;

        }else if (col.CompareTag("Player"))
        {

            duck.Life -= 1;

            duck.knockbackCount = 1;
           

        if(Rigid.transform.position.x > duck.DuckRigi.position.x)
            {
                duck.KnockDir = true;
            }else if (Rigid.transform.position.x < duck.DuckRigi.position.x)
            {
                duck.KnockDir = false;
            }
        }
        
    }
}

