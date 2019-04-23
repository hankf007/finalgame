using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor2 : MonoBehaviour



{
    public Scoremanager scoremanager;





    // Start is called before the first frame update
    void Start()
    {
        scoremanager = GameObject.FindWithTag("Scoremanager").GetComponent<Scoremanager>(); //calls scoremanager
    }



    void OnCollisionEnter2D(Collision2D other) //on the ground
    {
        if (other.gameObject.name == "player1")
        {
            scoremanager.score2 += 1; //player 1 gains 1 point

        }



    }


}
