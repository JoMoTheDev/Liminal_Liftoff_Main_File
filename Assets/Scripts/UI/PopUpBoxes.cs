using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
using UnityEngine.Audio; 
using TMPro; 
public class PopUpBox : MonoBehaviour 
{ 
    public GameObject previousGFX; 
    public GameObject currentGFX; 
    public GameObject nextGFX; 
    void Start() 
    { 
        currentGFX.SetActive(true); 
    } 
    void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        { 
            Back(); 
        } 
        if (Input.GetKeyDown(KeyCode.Return)) 
        { 
            Next(); 
        } 
    } 
    void Back() 
    { 
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None; 
        currentGFX.SetActive(false); 
        nextGFX.SetActive(false); 
        previousGFX.SetActive(true); } 
    void Next() 
    { 
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None; 
        previousGFX.SetActive(false); 
        currentGFX.SetActive(false);
         nextGFX.SetActive(true); 
    } 
    void Exit() 
    { 
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    } 
}
