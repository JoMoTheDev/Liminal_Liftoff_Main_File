using UnityEngine;

public class RocketPart : MonoBehaviour
{
    private LevelManager levelManager;
    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>().GetComponent<LevelManager>();
    }

    public void PartCollected()
    {
        levelManager.AddShipParts();
    }
}
