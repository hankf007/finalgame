using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundplayer : MonoBehaviour
{

    public AudioClip soundeffect1;
    public AudioClip soundeffect2;




    public GameObject player;




    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Ball" )
        {
            AudioSource.PlayClipAtPoint(soundeffect1, transform.position);

           

        }


        if (other.gameObject == player)
        {
            AudioSource.PlayClipAtPoint(soundeffect2, transform.position);



        }
        
    }






}

