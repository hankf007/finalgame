using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (Input.GetKeyUp(KeyCode.DownArrow)) //select quit
        {
            transform.position = new Vector2(-1.68f, -2.31f);

        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) //select start
        {
            transform.position = new Vector2(-1.68f, -0.77f);

        }

    }
}
