using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("InfiniteTrain");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
