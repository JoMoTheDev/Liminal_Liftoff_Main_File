using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public int dialogToPlay;
    public bool canPlay;
    public DialogTrigger dialogTrigger;
    public GameObject triggerObject;
    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == triggerObject)
        {
            if (canPlay)
            {
                levelManager.PlayDialog(dialogToPlay);
                canPlay = false;
            }

            if (dialogTrigger  != null)
            {
                dialogTrigger.canPlay = true;
            }
        }
    }
}
