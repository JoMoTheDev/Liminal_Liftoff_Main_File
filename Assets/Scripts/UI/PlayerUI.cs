//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class PlayerUI : MonoBehaviour
//{
//    public GameObject pauseMenu;
//    public GameObject gunMenu;
//    public GameObject gravity;
//    public GameObject force;
//    public GameObject shoot;
//    public GameObject grab;
//    bool isPaused = false;
//    bool isHover = false;

//    // Smoothly rotates towards a 90-degree Y-axis rotation
//    float smooth = 5.0f;
//    Quaternion gravityRotation = Quaternion.Euler(0, 0, 0);
//    Quaternion forceRotation = Quaternion.Euler(0, 90, 0);
//    Quaternion shootRotation = Quaternion.Euler(0, 90, 0);
//    Quaternion grabRotation = Quaternion.Euler(0, 90, 0);

//    void Update()
//    {
//        if(Input.GetKeyDown(KeyCode.Tab))
//        {
//            if (isPaused)
//            {
//                ResumeGame();
//            }
//            else
//            {
//                PauseGame();
//            }
//        }
//        if (Input.GetKeyDown(Keycode.Q))
//        {
//            Debug.Log("GunMenu");
//        }
//    }

//    void Gun()
//    {
//        if (gunMenu != null) 
//        { 
//            if (gravity.Hover = true)
//            {
//                transform.rotation = Quaternion.Slerp(transform.rotation, gravityRotation, Time.deltaTime * smooth);
//            }
//            if (force.Hover = true)
//            {
//                transform.rotation = Quaternion.Slerp(transform.rotation, forceRotation, Time.deltaTime * smooth);
//            }
//            if (shoot.Hover = true)
//            {
//                transform.rotation = Quaternion.Slerp(transform.rotation, forceRotation, Time.deltaTime * smooth);
//            }
//            if (grab.Hover = true)
//            {
//                transform.rotation = Quaternion.Slerp(transform.rotation, forceRotation, Time.deltaTime * smooth);
//            }
//        }

//    }
    
//    void PauseGame()
//    {
//        Time.timeScale = 0;
//        pauseMenu.SetActive(true);

//        Cursor.visible = true;
//        Cursor.lockState = CursorLockMode.None;
//        isPaused = true;
//    }

//    void ResumeGame()
//    {
//        Time.timeScale = 1;
//        pauseMenu.SetActive(false);
//        isPaused = false;

//        Cursor.visible = false;
//        Cursor.lockState = CursorLockMode.Locked;  
        
//    }

//    public void LoadMenu()
//    {
//        SceneManager.LoadScene("Userinterface");
//    }
//}
