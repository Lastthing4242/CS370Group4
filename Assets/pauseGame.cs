using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour
{
    public void doPause()
    {
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }
}
