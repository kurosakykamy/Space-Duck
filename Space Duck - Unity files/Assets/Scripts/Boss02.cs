using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss02 : MonoBehaviour {

    public bool start;
    public int Life;
    public DuckController duck;
    public Rigidbody2D BossRigid;
    public GameObject AcidBall;
    public GameObject Tail;
    public Transform AcidSP;
    public int Count;
    public float AcidTimer;
    public float Tailtimer;
    public float hitCount;
    public Animator Anime;
    public float Aux;
    public float DeadTimer;
    public Sav sav;

    // Use this for initialization
    void Start () {
        Count = 0;
        hitCount = 3;
        Life = 8;
        Aux = 0;
}
	
	// Update is called once per frame
	void Update () {
        sav = GameObject.Find("Save").GetComponent<Sav>();
        if (Life <= 0)
        {
            Anime.SetBool("Lose", true);
            Count = 4;
            sav.CheckPoint = false;
            DeadTimer += Time.deltaTime;
            if (DeadTimer > 3f)
            {
                SceneManager.LoadScene("Transition");
            }
        } else if (Life < 4)
        {
            hitCount = 5;
        }


        if (start)
        {
            if (Count == 0)
            {
                Aux += Time.deltaTime;
                if(Aux > 2.2)
                {
                    Anime.SetBool("acid", true);
                    AcidTimer += Time.deltaTime;
                    if (AcidTimer > hitCount)
                    {
                        Anime.SetBool("acid", false);
                        Count = 1;
                        AcidTimer = 0;
                    }
                }
            }
            else if (Count == 1)
            {
                
                Anime.SetBool("Tail", true);
                Tailtimer += Time.deltaTime;
                if(Tailtimer >=  1f)
                {
                    Anime.SetBool("Tail", false);
                    Tailtimer = 0;
                    Count = 2;
                    Aux = 0;
                }
            }
            else if (Count == 2)
            {
                Aux += Time.deltaTime;
                if(Aux > 2.2)
                {
                    Anime.SetBool("Tail", true);
                    Tailtimer += Time.deltaTime;
                    if (Tailtimer >= 1f)
                    {
                        Anime.SetBool("Tail", false);
                        Tailtimer = 0;
                        Count = 0;
                        Aux = 0;
                    }
                }
            }



        }
    }

    void TailAtk()
    {
        if (Tail != null)
        {
            var ClTail = Instantiate(Tail, new Vector3(614.26f, -10.5f,0), Quaternion.identity) as GameObject;
        }

    }

    void AcidShot()
    {
        if (AcidBall != null)
        {
            var ClAcid = Instantiate(AcidBall, AcidSP.position, Quaternion.identity) as GameObject;
        }

    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Attk"))
        {
            Life -= 1;

        }
        else if (col.CompareTag("Player"))
        {

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

    }
}
