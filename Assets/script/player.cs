using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
    

{
    //public bool isplayer1;
    //public bool isplayer2;

    public Rigidbody2D RB;
    public float Speed;
    public float Jumpvel;

    private bool Jump;

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;

    public KeyCode kick;

  

    public Animator Animator;


    public bool kicking = false;
    float animationDuration=1f; // Animation time in seconds


    public float powerbar=0;
    public Text power;
    public KeyCode powerkey;

    public GameObject portalin;


    public int amountForceX;
    public int amountForceY;

    public AudioSource portalinsound;


    






    // Update is called once per frame
    void Update()
    {
        Animator.SetBool("isKicking", false);
        Animator.SetBool("isJumping", false);

        Vector3 vel = RB.velocity;
        if (Input.GetKey(right))
        {
            vel.x = Speed;

            

            Animator.SetFloat("Speed", Mathf.Abs(vel.x)); //anim transits from idle to walk when speeds

        }
        else if (Input.GetKey(left))
        {
            vel.x = -Speed;

           

            Animator.SetFloat("Speed", Mathf.Abs(vel.x)); //anim transits from idle to walk when speeds

        }
        else
        {
            vel.x = 0;
            Animator.SetFloat("Speed", Mathf.Abs(vel.x));
        }

        if ((Input.GetKeyDown(up)) && (Jump==true)) //can only jump if on the ground
        {
            vel.y = Jumpvel;
            Animator.SetBool("isJumping", true); //play jump anim 

            Jump = false;
        }

        RB.velocity = vel;

        if (Input.GetKey(kick))
        {

            Animator.SetBool("isKicking", true);

        }

            if (Input.GetKey(kick)  && GameObject.Find("ball").GetComponent<ball>().cankick1==true) //only the player touching the ball can kick it
        {
            if(gameObject.name=="player1")
            { 

            Kick();

            Animator.SetBool("isKicking", true);
        }
       

        }
        if (Input.GetKey(kick) && GameObject.Find("ball").GetComponent<ball>().cankick2 == true)//only the player touching the ball can kick it
        {
            if (gameObject.name == "player2")

                

                Kick();

            Animator.SetBool("isKicking", true);
        }



        if (powerbar < 100)
        {
            powerbar += 5 * Time.deltaTime; //increase power automatically
            power.text = powerbar.ToString();

            

            
        }

        if (Input.GetKey(powerkey) && powerbar >= 100)
        {
            Power();
           
        }

        
        //Debug.Log(GameObject.Find("energy1").GetComponent<energy>().scale.x);



    }

    void OnCollisionEnter2D(Collision2D other) //on the ground
    {
        if (other.gameObject.tag == "Floor")
        {
            
                Jump = true;

               // Debug.Log("True ");
            
        }

        /*if (other.gameObject.tag == "Ball" && kicking == true)
          {

             // Vector3 direction = (other.transform.position - transform.position).normalized;
             // ballscript.GetComponent<Rigidbody2D>().AddForce(transform.up * 500);
          }



       //ballscript = GetComponent<ball>();
*/
    }
    

   /* void OnCollisionExit2D(Collision2D other) //in the air
    {
        if (other.gameObject.tag == "Floor")
        {

            
                Jump = false;
                Debug.Log("False");

             
            


        }
    }

    */

    private void Kick()
    {
    
        // Invoke("StopKicking", animationDuration); //set kick to false after animation


        Invoke("StopKicking", animationDuration); //set kick to false after animation

        if (!kicking)
        {
            // kicking = true;

            GameObject.Find("ball").GetComponent<ball>().RB.AddForce(new Vector2(amountForceX, amountForceY));
            GameObject.Find("ball").GetComponent<ball>().PlayParticle();

           // Debug.Log("kicktrue");



        }
    }
     
    private void StopKicking()
    {
        kicking = false;
        //Debug.Log("kickfalse");
        Animator.SetBool("isKicking", false);
    }
    

    private void Power() 
    {
    
       // Debug.Log("summon");
        portalin.SetActive(true);

        portalinsound.Play();
        

        
        StartCoroutine(Destroy());
      //  Debug.Log("destroyed");

        powerbar = 0;

    }

    private IEnumerator Destroy() //turn off portal
    {
        yield return new WaitForSeconds(5f);

        portalin.SetActive(false);
    }




}
