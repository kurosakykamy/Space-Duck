using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss01 : MonoBehaviour {

    public bool start;
    public Rigidbody2D BossRigid;
    public DuckController duck;
    public Transform RockSP;
    public GameObject Rock;
    public int Life;
    public int Count;
    private float WallCheckRadius = 0.2f;
    private bool InWall;
    public float Vel;
    public Transform WallCheck;
    public LayerMask IsWall;
    public bool Direita;
    public Animator Anime;
    public float ThrowTimer;
    public float ThrowStop;
    public float AcTimer;
    public bool Dead;
    public float DeadTimer;
    public Sav sav;

    // Use this for initialization
    void Start () {

        start = false;

    }
	
	// Update is called once per frame
	void Update () {
        sav = GameObject.Find("Save").GetComponent<Sav>();
        if (start)
        {
            InWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, IsWall);

            if (Life <= 0)
            {
                sav.CheckPoint = false;
                Dead = true;
                Anime.SetBool("Lose", true);
                Count = 4;
                BossRigid.velocity = new Vector2(0, BossRigid.velocity.y);
                DeadTimer += Time.deltaTime;
                if(DeadTimer > 3f)
                {
                    SceneManager.LoadScene("Transition");
                }
            }else if(Life <3)
            {
                ThrowStop = 4;
            }



            if (Count <= 2)
            {
                if (InWall)
                {
                    
                    Anime.SetBool("Run", false);
                    BossRigid.transform.localScale = new Vector2(-BossRigid.transform.localScale.x, BossRigid.transform.localScale.y);
                    this.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                    Direita = !Direita;
                    Count ++;
                }else if (!InWall && !Direita)
                {   
                    Anime.SetBool("Run", true);
                    BossRigid.velocity = new Vector2(-Vel, BossRigid.velocity.y);
                }else if (!InWall && Direita)
                {
                    Anime.SetBool("Run", true);
                    BossRigid.velocity = new Vector2(Vel, BossRigid.velocity.y);
                }

            }else if(Count == 3)
            {
                BossRigid.velocity = new Vector2(0, BossRigid.velocity.y);
                Anime.SetBool("Throw", true);
                if (Anime.GetBool("Throw"))
                {
                    ThrowTimer += Time.deltaTime;
                    if(ThrowTimer >= ThrowStop)
                    {   
                        Anime.SetBool("Throw", false);
                        AcTimer += Time.deltaTime;
                        if(AcTimer >= 2f)
                        {
                            AcTimer = 0;
                            Count = 0;
                            ThrowTimer = 0;
                        }
                        
                    }

                }
            }

        }
	}


    void Throw()
    {
        if (Rock != null)
        {
            var ClRock = Instantiate(Rock, RockSP.position, Quaternion.identity) as GameObject;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            duck.Life -= 1;
            duck.knockbackCount = 1;
            
                       
            if (BossRigid.transform.position.x > duck.DuckRigi.position.x)
            {
                duck.KnockDir = true;
            }
            else if (BossRigid.transform.position.x < duck.DuckRigi.position.x)
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
