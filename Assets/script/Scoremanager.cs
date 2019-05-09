using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Scoremanager : MonoBehaviour




     
{
    public Text scoreText1;
    public Text scoreText2;

    public int score1;
    public int score2;

    

    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
        score2 = 0;
    }

    // Update is called once per frame
    void Update()
    {

        scoreText1.text = score1.ToString();

        scoreText2.text = score2.ToString();

       

       if(score1 == 1)
        {
            SceneManager.LoadScene("End1");
        }

        if (score2 == 1)
        {
            SceneManager.LoadScene("End2");
        }

    }



}
