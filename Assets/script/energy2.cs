using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class energy2 : MonoBehaviour

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
        xpos = 5.885f;
        ypos = 2.53f;
    }

    // Update is called once per frame
    void Update()
    {

        xscale = (1 + (GameObject.Find("player2").GetComponent<player>().powerbar / 5));

        transform.localScale = new Vector2(xscale, yscale);

        //transform.localScale = scale;

        xpos = (GameObject.Find("player2").GetComponent<player>().powerbar / 120) + 5.885f;

        transform.position = new Vector2(xpos, ypos);


    }
}
