using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gunMenu;
    bool isPaused = false;
    bool gunMenuOpen;

    //Smoothly rotates towards a 90-degree Y-axis rotation
    float smooth = 5.0f;
    Quaternion targetRotation = Quaternion.identity;

    Quaternion gravityRotation = Quaternion.Euler(0, 0, 0);
    Quaternion lightRotation = Quaternion.Euler(0, 0, 90);
    Quaternion forceRotation = Quaternion.Euler(0, 0, 180);
    Quaternion shootRotation = Quaternion.Euler(0, 0, 270);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && !isPaused)
        {
            gunMenuOpen = !gunMenuOpen;
            Gun();
        }
        if (gunMenuOpen)
        {
            GunControls();
        }
    }

    void Gun()
    {
        if (gunMenu != null && gunMenuOpen)
        {
            print("gun");
            Time.timeScale = 0;
            gunMenu.SetActive(true);
        }
        else
        {
            print("gun unpause");
            Time.timeScale = 1;
            gunMenu.SetActive(false);
        }

    }

    void GunControls()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("gravity");
            targetRotation = gravityRotation;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("light");
            targetRotation = lightRotation;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("force");
            targetRotation = forceRotation;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("shoot");
            targetRotation = shootRotation;
        }
        gunMenu.transform.rotation = Quaternion.Lerp(gunMenu.transform.rotation, targetRotation, smooth * Time.unscaledDeltaTime);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Userinterface");
    }
}
