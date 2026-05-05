using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimonManager : MonoBehaviour
{
    public float lightChangeTime = 0.15f;
    public float LightLoopTime = 2f;
    private float currentLightLoop;
    private int simonInt = 0;
    public string[] simonCode;
    public GameObject[] simonLights;
    public List<GameObject> lightsToFlash;

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>().GetComponent<LevelManager>();
        lightsToFlash = new List<GameObject>();
        AssignLights();
    }

    void Update()
    {
        if (currentLightLoop >= LightLoopTime)
        {
            StartCoroutine(SimonLightLoop());
            currentLightLoop = 0;
        }
        else
        {
            currentLightLoop += Time.deltaTime;
        }
    }

    public void SolveSimon(string buttonColor)
    {
        if (buttonColor == simonCode[simonInt] && simonInt == (simonCode.Length - 1))
        {
            print("solved");
            levelManager.LoadScene();
        }
        else if (buttonColor == simonCode[simonInt])
        {
            print("correct " + simonCode[simonInt]);
            simonInt += 1;
        }
        else
        {
            print("wrong " + simonCode[simonInt]);
            simonInt = 0;
        }
        currentLightLoop = 0;
        StopCoroutine(SimonLightLoop());

        StartCoroutine(ActivateLight());
    }

    void AssignLights()
    {
        print("assign lights start");

        foreach (string code in simonCode)
        {
            switch (code)
            {
                case "Green":
                    lightsToFlash.Add(simonLights[0]);
                    break;
                case "Yellow":
                    lightsToFlash.Add(simonLights[1]);
                    break;
                case "Red":
                    lightsToFlash.Add(simonLights[2]);
                    break;
                case "Blue":
                    lightsToFlash.Add(simonLights[3]);
                    break;
            }
            print(code);
        }
    }

    IEnumerator SimonLightLoop()
    {
        for (int i = 0; i <= simonInt; i++)
        {
            lightsToFlash[i].SetActive(true);
            yield return new WaitForSeconds(lightChangeTime);
            lightsToFlash[i].SetActive(false);
        }
    }   

    IEnumerator ActivateLight()
    {
        lightsToFlash[simonInt].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        lightsToFlash[simonInt].SetActive(false);
    }
}
