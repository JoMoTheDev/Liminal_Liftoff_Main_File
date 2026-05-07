using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimonManager : MonoBehaviour
{
    public float lightChangeTime = 0.15f;
    public float LightLoopTime = 2f;
    private float currentLightLoop;
    private int simonInt = 0;
    private int simonListInt = 0;
    public string[] simonCode;
    public GameObject[] simonLights;
    private List<GameObject> lightsToFlash;
    private List<string> simonSoFar;

    public AudioSource simonSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    public AudioClip nextRoundSound;

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>().GetComponent<LevelManager>();
        lightsToFlash = new List<GameObject>();
        simonSoFar = new List<string>();
        simonSoFar.Add(simonCode[0]);
        simonSoFar.Add(simonCode[1]);
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

        if (buttonColor == simonSoFar[simonListInt] && buttonColor == simonCode[simonInt])
        {
            simonSource.PlayOneShot(nextRoundSound);
            print("== correct " + simonCode[simonInt]);
            if (simonInt > 0 && simonInt != (simonCode.Length - 1))
            {
                simonSoFar.Add(simonCode[simonInt + 1]);
            }
            simonInt++;
            simonListInt = 0;
        }
        else if (buttonColor == simonSoFar[simonListInt] && buttonColor != simonCode[simonInt])
        {
            simonSource.PlayOneShot(correctSound);
            print("!= correct " + simonCode[simonListInt]);
            simonListInt++;
        }
        else
        {
            simonSource.PlayOneShot(wrongSound);
            print("wrong " + simonCode[simonListInt]);
            simonInt = 0;
            simonListInt = 0;
        }
        currentLightLoop = 0;
        StopAllCoroutines();

        StartCoroutine(ActivateLight(buttonColor));
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

        foreach (GameObject light in simonLights)
        {
            light.SetActive(false);
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

    IEnumerator ActivateLight(string lightColor)
    {
        switch (lightColor)
        {
            case "Green":
                simonLights[0].SetActive(true);
                break;
            case "Yellow":
                simonLights[1].SetActive(true);
                break;
            case "Red":
                simonLights[2].SetActive(true);
                break;
            case "Blue":
                simonLights[3].SetActive(true);
                break;
        }
        yield return new WaitForSeconds(0.5f);
        simonLights[0].SetActive(false);
        simonLights[1].SetActive(false);
        simonLights[2].SetActive(false);
        simonLights[3].SetActive(false);
    }
}
