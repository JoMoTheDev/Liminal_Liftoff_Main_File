using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject bricks;
    public int shipPartsToCollect;
    private int shipPartsCollected;
    public int notesToCollect;
    private int notesCollected;
    private LivingRoomTV roomTV;

    void Start()
    {
        roomTV = FindFirstObjectByType<LivingRoomTV>().GetComponent<LivingRoomTV>();
    }

    public void AddNote()
    {
        notesCollected++;

        if (notesCollected >= notesToCollect)
        {
            if (bricks != null)
            {
                bricks.SetActive(true);
            }
        }
    }

    public void AddShipParts()
    {
        shipPartsCollected++;

        if (shipPartsCollected >= shipPartsToCollect)
        {
            if (roomTV != null)
            {
                roomTV.isOn = true;
            }
        }
    }
}
