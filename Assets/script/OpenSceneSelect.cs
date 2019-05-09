using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneSelect : MonoBehaviour
{

    public bool start;

    // Start is called before the first frame update
    void Start()
    {
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow)) //select quit
        {
            transform.position = new Vector2(-1.29f, -2.42f);

            start = false;
            
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) //select start
        {
            transform.position = new Vector2(-1.29f, -1.5f);
            start = true;
        }

        if(Input.GetKeyDown(KeyCode.Return)&&start==true)
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if (Input.GetKeyDown(KeyCode.Return) && start == false)
        {
            Application.Quit();
        }

    }
}
