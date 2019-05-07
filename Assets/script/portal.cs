using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour

{


    private float nextActionTime = 5;
    public float period = 0.1f;

    

  //  public Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

       /* if (Time.time > nextActionTime) //execute every x seconds
        {
            nextActionTime += period;
            gameObject.transform.position = new Vector2(RandomExcept(-6,6,0), Random.Range(0, 4)) ; //move to random spot
            Debug.Log("portal'sowndebug"+gameObject.transform.position);

            
        } */
    }


    public int RandomExcept(int x, int y, int except) //portal won't go to middle
    {

        int random = except;

        while (random == except)
        {
            random = Random.Range(x, y);
        }

        return random;
    }

}
