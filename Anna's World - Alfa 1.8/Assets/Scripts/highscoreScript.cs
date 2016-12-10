using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class highscoreScript : MonoBehaviour
{
    public GameObject score;
    public GameObject user;
    public GameObject password;


    public void setScore(String user, String password, String score)
    {

        this.user.GetComponent<Text>().text = user;
        this.score.GetComponent<Text>().text = score;

    }

    
}
