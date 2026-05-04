using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] dialog;
    public GameObject[] notes;
    public GameObject bricks;
    public GameObject gunGFX;
    public BlasterSwitch blasterSwitch;
    List<Transform> dialogSequence;
    public int shipPartsToCollect;
    private int shipPartsCollected;
    public int notesToCollect;
    private int notesCollected;
    private int dialogSeqIndex = 0;
    public LoadScene sceneLoader;
    public LivingRoomTV roomTV;
    private PlayerController playerController;


    private void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        dialogSequence = new List<Transform>();
        if (dialog.Length > 0)
        {
            PlayDialog(dialog.Length - 2);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dialogSequence.Count > 0)
        {
            if (dialogSeqIndex <= 0)
            {
                ExitDialog();
            }
            else
            {
                ChangeDialog(-1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && dialogSequence.Count > 0)
        {
            if (dialogSeqIndex >= dialogSequence.Count - 1)
            {
                ExitDialog();
            }
            else 
            {
                ChangeDialog(1);
            }
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

        if (dialog.Length > 0 && noteNumber == 0)
        {
            PlayDialog(noteNumber);
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

        if (dialog.Length > 0)
        {
            PlayDialog(partNumber);
        }
    }

    public void PickupBlaster()
    {
        gunGFX.SetActive(true);
        blasterSwitch.enabled = true;
        if (dialog.Length > 0)
        {
            PlayDialog(dialog.Length - 1);
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

    public void PlayDialog(int dialogBlock)
    {
        GameObject block = dialog[dialogBlock];

        foreach (Transform dialog in block.transform)
        {
            dialogSequence.Add(dialog);
        }

        dialogSequence[dialogSeqIndex].gameObject.SetActive(true);
    }

    void ChangeDialog(int dialogChange)
    {
        dialogSequence[dialogSeqIndex].gameObject.SetActive(false);
        dialogSeqIndex += dialogChange;
        dialogSequence[dialogSeqIndex].gameObject.SetActive(true);
    }

    public void ExitDialog()
    {
        dialogSequence[dialogSeqIndex].gameObject.SetActive(false);
        dialogSeqIndex = 0;
        dialogSequence.Clear();

        if (sceneLoader != null)
        {
            LoadScene();
        }
    }
}
