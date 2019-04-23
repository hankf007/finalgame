using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballspawner : MonoBehaviour
{

    public GameObject ball;

 

    public Vector3 Pos;
   

   



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            SpawnBall();
        }
    }


    




    private void SpawnBall()
    {
        Instantiate(ball, Pos, Quaternion.identity);
    }

    

}
