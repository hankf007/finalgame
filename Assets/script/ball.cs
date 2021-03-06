﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    private SpriteRenderer sr;
    public Rigidbody2D RB;

    public Scoremanager scoremanager;


    public Animator anim;

    public AudioSource collision;
    //public AudioSource portalinsound;
    public AudioSource portaloutsound;
    public AudioSource score;

    public GameObject portalout;
    public GameObject portalin1;
    public GameObject portalin2;


   // public int amountForceX1;
   // public int amountForceX2;
   // public int amountForceY;

    public int portalForceX1;
    public int portalForceX2;
    public int portalForceY;


    public int Spawnx1;
    public int Spawnx2;
    public int Spawny;

    public bool cankick1;
    public bool cankick2;

    public ParticleSystem particle;

    public Vector2 particlepos;


    // public player player1;

    //public float kickForce;







    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        scoremanager = GameObject.FindWithTag("Scoremanager").GetComponent<Scoremanager>(); //calls scoremanager

        //  player1 = GetComponent<player>();\

        
        


    }



    void Update()
    {
        // Debug.Log(cankick);
        particlepos = gameObject.transform.position;
    }


    void OnCollisionEnter2D(Collision2D other)
    {

        

       


        if (other.gameObject.name == "ground1")
        { //if ball falls onto ground the power decreases
            collision.Play();

            if (GameObject.Find("player1").GetComponent<player>().powerbar <= 10)
            {
                GameObject.Find("player1").GetComponent<player>().powerbar = 0;
            }

            else 
            {
                GameObject.Find("player1").GetComponent<player>().powerbar -= 10;

            }

            PlayParticle();
        }
        else if (other.gameObject.name == "ground2")
        {
            collision.Play();
            //if ball falls onto ground the power decreases

            if (GameObject.Find("player2").GetComponent<player>().powerbar <= 10)
            {
                GameObject.Find("player2").GetComponent<player>().powerbar = 0;
            }

            else
            {
                GameObject.Find("player2").GetComponent<player>().powerbar -= 10;

            }
            PlayParticle();
        }

        




        else if (other.gameObject.name == "goal1")
               {

            score.Play();
                

            scoremanager.score2 += 1; //player 1 gains 1 point

            RB.velocity = Vector3.zero; //set velocty to 0

            gameObject.transform.position = new Vector2(Spawnx2,Spawny);
                
           



            // Destroy(gameObject); //self destruct



        }
           else if (other.gameObject.name == "goal2")
           {
            score.Play();



            scoremanager.score1 += 1; //player 1 gains 1 point


            RB.velocity = Vector3.zero; //set velocti to 0

            gameObject.transform.position = new Vector2(Spawnx1, Spawny);




            // Destroy(gameObject); //self destruct



        }

        else if (other.gameObject.name == "player1")
        {
            collision.Play();
            PlayParticle();
        }

        else if (other.gameObject.name == "player2")
        {
            collision.Play();
            PlayParticle();
        }



        particlepos = gameObject.transform.position; 


    }
    void OnTriggerEnter2D(Collider2D other)

    {
        

        if (other.gameObject.name == "player1")
        {
            cankick1 = true;

            //  anim.SetBool("isorange", false);


            //  Debug.Log("1");

         //   if (GameObject.Find("player1").GetComponent<player>().kicking == true)
          //  {
           //     Debug.Log("kicked");
               // RB.AddForce(new Vector2(amountForceX1, amountForceY)); // kick the ball


                // Vector3 direction = (other.transform.position - transform.position).normalized;
                // GetComponent<Rigidbody2D>().AddForce(transform.up * kickForce);
          //  }
        }


        else if (other.gameObject.name == "player2")

        {
            cankick2 = true;
            //  anim.SetBool("isorange", true);


            //  Debug.Log("2");

          //  if (GameObject.Find("player2").GetComponent<player>().kicking == true)
          //  {
           //     Debug.Log("kicked");
              //  RB.AddForce(new Vector2(amountForceX2, amountForceY)); // kick the ball


                // Vector3 direction = (other.transform.position - transform.position).normalized;
                // GetComponent<Rigidbody2D>().AddForce(transform.up * kickForce);
          //  }
        }

        else if (other.gameObject.name == "portalin1")
        {
            portaloutsound.Play();


            portalout.SetActive(true);
            GameObject.FindWithTag("portalout").transform.position = new Vector2(4, 0); //summon portal out
            gameObject.transform.position = GameObject.FindWithTag("portalout").transform.position;

            RB.velocity = Vector3.zero; //set velocti to 0


            RB.AddForce(new Vector2(portalForceX1, portalForceY)); //give new velocity

            portalin1.SetActive(false); //deactivate portalin

            StartCoroutine(Destroy()); //deactivate portalout

          

            // Debug.Log("portalout"+portalout.transform.position);


        }
        else if (other.gameObject.name == "portalin2")
        {
            portaloutsound.Play();

            portalout.SetActive(true);
            GameObject.FindWithTag("portalout").transform.position = new Vector2(-4, 0); //summon portal out
            gameObject.transform.position = GameObject.FindWithTag("portalout").transform.position;

            RB.velocity = Vector3.zero; //set velocti to 0

            RB.AddForce(new Vector2(portalForceX2, portalForceY));

            portalin2.SetActive(false);

            StartCoroutine(Destroy());

           


            // Debug.Log("portalout"+portalout.transform.position);


           
        }
    }


    void OnTriggerStay2D(Collider2D other)

    {
        //make sure if both players touch the ball and one leaves the other can still kick the ball


        if (other.gameObject.name == "player1")
        {
            cankick1 = true;

            
        }


        else if (other.gameObject.name == "player2")

        {
            cankick2 = true;
         
        }

    }

    void OnTriggerExit2D(Collider2D other)

    {
        cankick1 = false;
        cankick2 = false;
    }


        private IEnumerator Destroy() //turn off portal
    {
        yield return new WaitForSeconds(2f); //wait 2 secs until portal disappear

        portalout.SetActive(false);

        
    }

    public void PlayParticle()
    {
        Instantiate(particle, particlepos, Quaternion.identity);
        
    }








}
