using UnityEngine;

public class Note : MonoBehaviour
{
    private LevelManager levelManager;
    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>().GetComponent<LevelManager>();
    }

    public void NoteCollected()
    {
        levelManager.AddNote();
    }
}
