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
    float animationDuration=0.5f; // Animation time in seconds


    public float powerbar=0;
    public Text power;
    public KeyCode powerkey;

    public GameObject portalin;


    public int amountForceX;
    public int amountForceY;






    // Update is called once per frame
    void Update()
    {
        

        Vector3 vel = RB.velocity;
        if (Input.GetKey(right))
        {
            vel.x = Speed;
           
        }
        else if (Input.GetKey(left))
        {
            vel.x = -Speed;
           
        }
        else
        {
            vel.x = 0;
        }
        if ((Input.GetKeyDown(up)) && (Jump==true)) //can only jump if on the ground
        {
            vel.y = Jumpvel;
          
        }
        RB.velocity = vel;

        if(Input.GetKey(kick)&& GameObject.Find("ball").GetComponent<ball>().cankick==true)
        {
            Kick();
        }

        

        if (powerbar < 100)
        {
            powerbar += 5 * Time.deltaTime; //increase power automatically
            power.text = powerbar.ToString();
        }

        if (Input.GetKey(powerkey) && powerbar >= 10)
        {
            Power();
        }






    }

    void OnCollisionEnter2D(Collision2D other) //on the ground
    {
        if (other.gameObject.tag == "Floor")
        {
            Jump = true;
            //Debug.Log("True ");

        }

        /*if (other.gameObject.tag == "Ball" && kicking == true)
          {

             // Vector3 direction = (other.transform.position - transform.position).normalized;
             // ballscript.GetComponent<Rigidbody2D>().AddForce(transform.up * 500);
          }



       //ballscript = GetComponent<ball>();
*/
    }


    void OnCollisionExit2D(Collision2D other) //in the air
    {
        if (other.gameObject.tag == "Floor")
        {
            Jump = false;
           // Debug.Log("False");
        }
    }


    private void Kick()
    {
        if (!kicking)
        {
            // kicking = true;

            GameObject.Find("ball").GetComponent<ball>().RB.AddForce(new Vector2(amountForceX, amountForceY));

            Debug.Log("kicktrue");
            Animator.SetBool("isKicking", true);
           // Invoke("StopKicking", animationDuration); //set kick to false after animation
        }
    }

    private void StopKicking()
    {
        kicking = false;
        Debug.Log("kickfalse");
        Animator.SetBool("isKicking", false);
    }
    

    private void Power() 
    {
    
        Debug.Log("summon");
        portalin.SetActive(true);
        

        
        StartCoroutine(Destroy());
        Debug.Log("destroyed");

        powerbar = 0;

    }

    private IEnumerator Destroy() //turn off portal
    {
        yield return new WaitForSeconds(5f);

        portalin.SetActive(false);
    }




}
