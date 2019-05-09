using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class energy1 : MonoBehaviour

{
    public float xscale;
    public float yscale;

    public float xpos;
    public float ypos;

   


    // Start is called before the first frame update
    void Start()
    {
        xscale = 1;
        yscale = 1;
        xpos = -7.593f;
        ypos = 2.53f;

       
    }

    // Update is called once per frame
    void Update()
    {

        xscale = (1+ (GameObject.Find("player1").GetComponent<player>().powerbar/5)) ;

        transform.localScale = new Vector2(xscale, yscale);

        //transform.localScale = scale;

        xpos = (GameObject.Find("player1").GetComponent<player>().powerbar/120) - 7.593f;

        transform.position = new Vector2(xpos, ypos);


        /*    while (xscale > 1) {

                Invoke("Enable", 0.5f);
                Invoke("Disable", 0.5f);
            }





           */

    }

    /*private void Enable()
   {
       gameObject.SetActive(true);
   }

   private void Disable()
   {
       gameObject.SetActive(false);
   }
   */
}
