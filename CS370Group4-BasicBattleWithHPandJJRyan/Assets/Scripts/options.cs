using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    public void doOptions()//start function
    {
        //Debug.Log("Options button was clicked");//debug line, testing if button works
        SceneManager.LoadScene("gameOptions");//changes the scene when button is clicked
        //The string in load scene should be changed to the option scene's name
    }
}
