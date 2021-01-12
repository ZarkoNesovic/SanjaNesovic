﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame


    //Definisanje brzine kojom se robot krece
    public float topSpeed = 10f;
    /*
        Smer u kojem se karakter nalazi.U slucaju 2D platformske igre bitno je proveriti da li karakter gleda levo ili desno.
        Za to nam je potrebna jedna promenljiva tipa bool(moze da ima samo dve vrednosti tacno ili netacno) koja ce imati vrednost tacno ukoliko karakter gleda desno 
        a u koliko gleda levo bice netacno.
        */
    bool facingRight = true;

    //Uzeti referencu  animatora 
    Animator anim;

    //Nije na zemlji
    bool isGrounded = false;

    //Potreban nam je transform objekat GroungCheck-a da bi proverili da li su noge naseg karaktera na zemlji
    public Transform groundCheck;
    float groundRadius = 0.2f;//Velicina kruga za proveru zemlje

    public float jumpForce = 700f; //Jacina skoka

    //Koji nivo u nasoj igrici predstavlja zemlju
    public LayerMask whatIsGround;

    bool doubleJump = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //Sve sto je vezano za fiziku sveta nalazice se u ovoj funkciji
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", isGrounded);

        if (isGrounded)
        {
            doubleJump = false;
        }

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


        //Ova funkcija proverava unos smera sa tastature u ovom slucaju horizontalnog (strelice levo i desno) i na osnovu toga
        //vraca vrednos izmedju -1 i 1.Ukoliko je pritisnuta leva strelica bice -1 ukoliko je pritisnuta desna +1.U slucaju da 
        //nista nije pritisnuto bice 0;

        float move = Input.GetAxis("Horizontal");

        /*
        U narednoj funkciji potrebno je nasem katakteru saopstiti brzinu i smer kretanja to cinimo tako sto u zavisnosti od pritisnutog
        tastera karakteru menjamo svojstvo velocity kreiranjem odredjenog vektora.Prva promenljiva se samo menja zato sto se karakter strelicama 
        krece samo duz x ose dok osa y ostaje nepromenjena
          I y-osa
          I
     -     I    +
----------I------- x-osa
          I
          I
          I

        */

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //U animatoru smo definisali parametar Speed na osnovu koga ce nas karakter menjati stanja.Ovde samo dodeljujemo vrednost tom parametru
        anim.SetFloat("Speed", Mathf.Abs(move));


        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Update()
    {
        //Nije na zemlji
        if ((isGrounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            if (!doubleJump && !isGrounded)
            {
                doubleJump = true;
            }
        }

    }

    void Flip()
    {
        /*
    Ova vuncija sluzi da okrene karaktera levo ili desno i to cini mnozenjem vrednosti koja se nalazi u promenljivoj transform.localScale koju nas karakter poseduje
    i cija je vrednost javna te svako moze da je menja
     */
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}

