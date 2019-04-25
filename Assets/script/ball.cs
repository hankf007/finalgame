using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    private SpriteRenderer sr;
    public Rigidbody2D RB;

    public Scoremanager scoremanager;


    public Animator anim;

    public AudioClip buzzer;

    public GameObject portalout;

    

 








    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        scoremanager = GameObject.FindWithTag("Scoremanager").GetComponent<Scoremanager>(); //calls scoremanager

      


    }



    void Update()
    {
      
    }


    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.name == "player1")
        {
            anim.SetBool("isorange", false);


          //  Debug.Log("1");
        }


        else if (other.gameObject.name == "player2")
        {
            anim.SetBool("isorange", true);


          //  Debug.Log("2");
        }

        else if (other.gameObject.name == "portalin1" || other.gameObject.name == "portalin2")
        {
            gameObject.transform.position = GameObject.FindWithTag("portalout").transform.position;

           // Debug.Log("portalout"+portalout.transform.position);
            

        }



      /*   else if (other.gameObject.name == "net")
         {



             scoremanager.score2 += 1; //player 1 gains 1 point



             Destroy(gameObject); //self destruct



         }
         else if (other.gameObject.name == "net2")
         {



             scoremanager.score1 += 1; //player 1 gains 1 point



             Destroy(gameObject); //self destruct



         }

    */





    }

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.name == "goal1")

        {



            scoremanager.score2 += 1; //player 2 gains 1 point


          

           Destroy(gameObject); //self destruct




        }


        else if (other.gameObject.name == "goal2")
        {



            scoremanager.score1 += 1; //player 1 gains 1 point




            Destroy(gameObject); //self destruct


        }
    }







}
