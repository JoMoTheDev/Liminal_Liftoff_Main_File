using UnityEngine;

public class PickupableObject : MonoBehaviour
{
    public string objectType;
    public int objectNumber;
    private LevelManager levelManager;
    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>().GetComponent<LevelManager>();
    }

    public void ObjectCollected()
    {
        if (objectType == "Note")
        {
            levelManager.AddNote(objectNumber);
        }
        else if (objectType == "Part")
        {
            levelManager.AddShipParts(objectNumber);
        }
        else if (objectType == "Blaster")
        {
            levelManager.PickupBlaster();
        }
    }
}
