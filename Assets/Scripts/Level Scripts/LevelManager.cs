using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] dialog;
    public GameObject[] notes;
    public GameObject bricks;
    public GameObject gunGFX;
    public float dialogDelay = 10f;
    public int shipPartsToCollect;
    private int shipPartsCollected;
    public int notesToCollect;
    private int notesCollected;
    public LoadScene sceneLoader;
    public LivingRoomTV roomTV;
    private PlayerController playerController;


    private void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        if (dialog.Length > 0)
        {
            StartCoroutine(PlayDialog(0));
        }
    }

    public void AddNote(int noteNumber)
    {
        notesCollected++;

        if (notes.Length > 0)
        {
            ReadNote(noteNumber);
        }

        if (notesCollected >= notesToCollect)
        {
            if (bricks != null)
            {
                bricks.SetActive(true);
            }
        }

        if (dialog.Length > 0 && noteNumber > 0)
        {
            StartCoroutine(PlayDialog(noteNumber));
        }
    }

    public void AddShipParts(int partNumber)
    {
        shipPartsCollected++;

        if (shipPartsCollected >= shipPartsToCollect)
        {
            if (roomTV != null)
            {
                roomTV.isOn = true;
            }
        }

        if (dialog != null)
        {
            StartCoroutine(PlayDialog(partNumber));
        }

        if (sceneLoader != null)
        {
            LoadScene();
        }
    }

    public void PickupBlaster()
    {
        gunGFX.SetActive(true);
        if (dialog.Length > 0)
        {
            StartCoroutine(PlayDialog(2));
        }
    }

    public void LoadScene()
    {
        if (shipPartsCollected >= shipPartsToCollect && notesCollected >= notesToCollect)
        {
            sceneLoader.SceneLoad();
        }
    }

    void ReadNote(int noteNumber)
    {
        notes[noteNumber].SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerController.isPaused = true;
    }

    public void ExitNote()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerController.isPaused = false;

        if (sceneLoader != null)
        {
            LoadScene();
        }
    }

    IEnumerator PlayDialog(int dialogBlock)
    {
        GameObject block = dialog[dialogBlock];
        foreach (Transform dialog in block.transform)
        {
            dialog.gameObject.SetActive(true);
            yield return new WaitForSeconds(dialogDelay);
            dialog.gameObject.SetActive(false);
        }
    }
}
