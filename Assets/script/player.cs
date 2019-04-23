using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Sprite sprite1;
    public Sprite sprite2;

   





    // Update is called once per frame
    void Update()
    {
        

        Vector3 vel = RB.velocity;
        if (Input.GetKey(right))
        {
            vel.x = Speed;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1; //change sprite
        }
        else if (Input.GetKey(left))
        {
            vel.x = -Speed;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2; //change sprite
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


    }

    void OnCollisionEnter2D(Collision2D other) //on the ground
    {
        if (other.gameObject.tag == "Floor")
        {
            Jump = true;
            //Debug.Log("True ");

        }

      

    }


    void OnCollisionExit2D(Collision2D other) //in the air
    {
        if (other.gameObject.tag == "Floor")
        {
            Jump = false;
           // Debug.Log("False");
        }
    }




}
