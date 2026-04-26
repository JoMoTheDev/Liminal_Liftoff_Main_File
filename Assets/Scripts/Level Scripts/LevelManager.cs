using System.Collections;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] dialog;
    public GameObject[] notes;
    public GameObject bricks;
    public float dialogDelay = 10f;
    public int shipPartsToCollect;
    private int shipPartsCollected;
    public int notesToCollect;
    private int notesCollected;
    public LivingRoomTV roomTV;


    private void Start()
    {
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
            StartCoroutine(ReadNote(noteNumber));
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
    }

    public void PickupBlaster()
    {
        if (dialog.Length > 0)
        {
            StartCoroutine(PlayDialog(2));
        }
    }
    IEnumerator ReadNote(int noteNumber)
    {
        notes[noteNumber].SetActive(true);
        yield return new WaitForSeconds(dialogDelay);
        notes[noteNumber].SetActive(false);
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
