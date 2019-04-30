using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{

    public GameObject portal;



    // Start is called before the first frame update
    void Start()
    {
        Instantiate(portal, new Vector2(RandomExcept(-6, 6, 0), Random.Range(0, 4)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
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
