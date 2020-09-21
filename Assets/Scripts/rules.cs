using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rules : MonoBehaviour
{
    public void doRules()//rules function
    {
        //Debug.Log("Rules button was clicked");//debug line, testing if button works
        SceneManager.LoadScene("gameRules");//changes the scene when button is clicked
        //The string in load scene should be changed to rules scene name
    }
}
