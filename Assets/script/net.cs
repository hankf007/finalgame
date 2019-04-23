using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class net : MonoBehaviour
{

    public float min ;
    public float max ;


    // Start is called before the first frame update
    void Start()
    {

        min = transform.position.y;
        max = transform.position.y + 6;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.z); //goes back and forth across y axis

    }
}   
