using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public void doStart()//start function
    {
        //Debug.Log("Start button was clicked");//debug line, testing if button works
        SceneManager.LoadScene("ProjectWar_v.8.29.20");//changes the scene when button is clicked
        //The string in load scene should be changed to the game scene's name
    }
}
