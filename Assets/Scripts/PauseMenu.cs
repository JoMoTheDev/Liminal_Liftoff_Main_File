//using UnityEditor.VisionOS;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            //unpause game
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            pauseMenu.SetActive(false);
            isPaused = false;
        }
        else
        {
            //pause
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            pauseMenu.SetActive(true);
            isPaused = true;
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenuPC");
    }
    public void Quit()
    {

        Application.Quit();
    }
}
