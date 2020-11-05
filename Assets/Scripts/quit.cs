using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
  public void doQuit()//quit function
    {
        //Debug.Log("Game Quit");//this line can be removed, for testing purposes only
        Application.Quit();//quits game when button is clicked
    }
}
