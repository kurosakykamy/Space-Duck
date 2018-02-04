using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss03 : MonoBehaviour {

    public bool start;
    public int Life;
    public int Count;
    public DuckController duck;
    public Rigidbody2D BossRigid;
    public GameObject Laser;
    public GameObject Laser2;
    public Transform LaserSP;
    public Animator Anime;
    public float DeadTimer;
    public float shootTimer;
    public float shootStop;
    public float AcTimer;
    public bool Direita;
    public float Vel;
    public float StopTimer;
    public float runTimer;
    public int aux;
    public Sav sav;
    // Use this for initialization
    void Start () {
        start = false;
        Count = 0;
        aux = 0;
    }
	
	// Update is called once per frame
	void Update () {
        sav = GameObject.Find("Save").GetComponent<Sav>();
        if (start)
        {
            if (Life <= 0)
            {
                Anime.SetBool("Lose", true);
                Count = -1;
                BossRigid.velocity = new Vector2(0, BossRigid.velocity.y);
                DeadTimer += Time.deltaTime;
                sav.CheckPoint = false;
                if (DeadTimer > 3f)
                {
                    SceneManager.LoadScene("WIN");
                }
            }
            if (Life <=5)
            {
                shootStop = 4;
            }

            if (Count == 0 && Life >= 6)
            {
                Anime.SetBool("Shot1", true);
                if (Anime.GetBool("Shot1"))
                {
                    shootTimer += Time.deltaTime;
                    if (shootTimer >= shootStop)
                    {
                        Anime.SetBool("Shot1", false);
                        AcTimer += Time.deltaTime;
                        if (AcTimer >= 2f)
                        {
                            AcTimer = 0;
                            Count = 1;
                            shootTimer = 0;
                        }
                    }
                }

            }else if (Count == 0 && Life <=5)
            {
                Anime.SetBool("Shot2", true);
                if (Anime.GetBool("Shot2"))
                {
                    shootTimer += Time.deltaTime;
                    if (shootTimer >= shootStop)
                    {
                        Anime.SetBool("Shot2", false);
                        AcTimer += Time.deltaTime;
                        if (AcTimer >= 2f)
                        {
                            AcTimer = 0;
                            Count = 1;
                            shootTimer = 0;
                        }
                    }
                }

            }else if(Count == 1)
            {
                Anime.SetBool("Run", true);
                Count = 2;

            }
            else if (Count == 2)
            {
                runTimer += Time.deltaTime;
                if (runTimer >= 3.8f)
                {
                    BossRigid.velocity = new Vector2(0, BossRigid.velocity.y);
                    Anime.SetBool("Run", false);
                    if (!Anime.GetBool("Run"))
                    {
                        if(aux == 0)
                        {
                            stop();
                            aux++;
                        }
                        AcTimer += Time.deltaTime;
                        if (AcTimer >= 2f)
                        {
                            StopTimer = 0;
                            AcTimer = 0;
                            Count = 0;
                            aux = 0;
                            runTimer = 0;
                        }

                    }
                }
                
            }
        }
	}


        
    void stop()
    {
        BossRigid.transform.localScale = new Vector2(-BossRigid.transform.localScale.x, BossRigid.transform.localScale.y);
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        Direita = !Direita;
    }

    void run()
    {
        if (!Direita)
        {
            BossRigid.velocity = new Vector2(-Vel, BossRigid.velocity.y);
        }
        else if (Direita)
        {
            BossRigid.velocity = new Vector2(Vel, BossRigid.velocity.y);
        }
    }


    void Lasershot()
    {
        if (Laser != null)
        {
            var ClLaser = Instantiate(Laser, LaserSP.position, Quaternion.identity) as GameObject;
        }

    }

    void Lasershot2()
    {
        if (Laser2 != null)
        {
            var ClLaser2 = Instantiate(Laser2, LaserSP.position, Quaternion.identity) as GameObject;
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
