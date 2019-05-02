using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSceneSelect : MonoBehaviour
{
    int index = 0;
    public int totalOptions = 2;
    public float yOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.position = new Vector2(-2.04f, -2.31f);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            transform.position = new Vector2(-2.04f, -0.77f);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {

        }
    }
}
