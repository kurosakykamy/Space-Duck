using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuckController : MonoBehaviour {


    public Rigidbody2D DuckRigi;
    public int jumpforce;
    public float Vel;
    public SpriteRenderer Flip;
    public Animator Anime;
    public Transform GroundCheck;
    public Transform GroundCheck2;
    public Transform WallCheck;
    public Transform WallCheck2;
    public LayerMask IsGround;
    public float GroundRadius = 0.2f;
    private bool InGround;
    private bool InGround2;
    private bool InWall;
    private bool InWall2;
    private bool Crouch;
    public bool Direita = true;
    public int Life;
    public int MaxLife;
    public bool Dead = false;
    public float timeatk;
    public float knockback;
    public float knockbackTimer;
    public float knockbackCount;
    public bool KnockDir; 

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        // knockback-----------------------------------------------------------------------
       
        if (knockbackCount > 0.8)
        {
            Anime.SetBool("Damage", true);
            if (KnockDir)
            {
                DuckRigi.AddForce(new Vector2(-knockback*Time.deltaTime, DuckRigi.position.y));

            }
            else if (!KnockDir)
            {
                DuckRigi.AddForce(new Vector2(knockback * Time.deltaTime, DuckRigi.position.y));
            }
            knockbackCount -= Time.deltaTime;
        }else Anime.SetBool("Damage", false);

        if(knockbackCount > 0.8)
        {
            Anime.SetBool("Ground", false);
            Anime.SetBool("Atk", false);
            Anime.SetFloat("Speed", 0f);
            Anime.SetBool("Crouch", false);
            DuckRigi.velocity = new Vector2(0, DuckRigi.velocity.y);
        }
        // knockback-----------------------------------------------------------------------



        //vidas----------------------------------------------------------------------
        if (Life > MaxLife)
        {
            Life = MaxLife;
        }else if(Life <= 0)
        {
            Dead = true;
            Anime.SetBool("Dead", Dead);
        }
        if (Dead || (DuckRigi.position.y <= -12 && SceneManager.GetActiveScene().name != "lv3"))
        {
            
            Anime.SetBool("Ground", false);
            StartCoroutine("WaitDead");
            
        }
        
        //vidas------------------------------------------------------------------------

        //Verificar solo e parede--------------------------------------------------------
        InGround = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, IsGround);
        InGround2 = Physics2D.OverlapCircle(GroundCheck2.position, GroundRadius, IsGround);
        InWall = Physics2D.OverlapCircle(WallCheck.position, GroundRadius, IsGround);
        InWall2 = Physics2D.OverlapCircle(WallCheck2.position, GroundRadius, IsGround);
        //Verificar solo e parede--------------------------------------------------------


        //pular------------------------------------------------------------------------------

        if(InGround || InGround2 && knockbackCount < 0.8)
        Anime.SetBool("Ground", true);
        else { Anime.SetBool("Ground", false); }

        if (Input.GetButtonDown("Jump")  && !Crouch && (InGround || InGround2) && !Dead && !Anime.GetBool("Atk") && Time.timeScale == 1 && knockbackCount < 0.8)
        {
            DuckRigi.AddForce(new Vector2(DuckRigi.position.x, jumpforce));
           
        }
        //pular------------------------------------------------------------------------------

        //ataque----------------------------------------------------------------------------
        if (Anime.GetBool("Atk"))
        {
            timeatk += Time.deltaTime;
        }
        if (Input.GetButtonDown("Attack")) {
            Anime.SetBool("Atk", true);
        }
            
        if (timeatk > 0.3f)
        {
            Anime.SetBool("Atk", false);
            timeatk = 0;
        }
        
        //ataque----------------------------------------------------------------------------
    }

    void FixedUpdate() {

        

        //correr------------------------------------------------------------------------------
        float move = Input.GetAxis("run");
        Anime.SetFloat("Speed", Mathf.Abs(move));
        if (!Crouch && !InWall && !InWall2 && !Dead && !Anime.GetBool("Atk"))
        {
            DuckRigi.velocity = new Vector2(move * Vel, DuckRigi.velocity.y);
        }
        if (move > 0 && !Direita)
        {
            DuckRigi.transform.localScale = new Vector2(-DuckRigi.transform.localScale.x, DuckRigi.transform.localScale.y);
            Direita = true;
        }
        if (move < 0 && Direita)
        {
            DuckRigi.transform.localScale = new Vector2(-DuckRigi.transform.localScale.x, DuckRigi.transform.localScale.y);
            Direita = false;
        }

        //correr------------------------------------------------------------------------------

        //abaixar------------------------------------------------------------------------------
        if (Input.GetButton("Crouch") && move ==0 && !Dead && !Anime.GetBool("Atk") && knockbackCount < 0.8)
        {
            Crouch = true;

        }
        else
        {
            Crouch = false;
        }
        Anime.SetBool("Crouch", Crouch);
        //abaixar------------------------------------------------------------------------------

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
      
       if (col.CompareTag("heal"))
        {
            Life = MaxLife;
        }
    }

    IEnumerator WaitDead()
    {
        
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameOver");
    }


}
