using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    public void goBack()//start function
    {
        //Debug.Log("back button was clicked");//debug line, testing if button works
        SceneManager.LoadScene("mainTitle");//changes the scene when button is clicked
        //this button was for testing scenes in the menu, and can be removed later, or added to other scenes as needed
    }
}
