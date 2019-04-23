using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor1 : MonoBehaviour



{
    public Scoremanager scoremanager;





    // Start is called before the first frame update
    void Start()
    {
        scoremanager = GameObject.FindWithTag("Scoremanager").GetComponent<Scoremanager>(); //calls scoremanager
    }



    void OnCollisionEnter2D(Collision2D other) //on the ground
    {
        if (other.gameObject.name == "player2")
        {
            scoremanager.score1 += 1; //player 1 gains 1 point

        }



    }


}
