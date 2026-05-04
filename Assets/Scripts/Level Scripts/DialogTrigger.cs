using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public int dialogToPlay;
    public bool isPlayerActivated = false;
    public bool canPlay = false;
    public DialogTrigger dialogTrigger;
    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (canPlay)
        {
            if (isPlayerActivated && collision.gameObject.GetComponent<PlayerController>())
            {
                levelManager.PlayDialog(dialogToPlay);
            }
            else if (collision.gameObject.GetComponent<PickupableObject>())
            {
                levelManager.PlayDialog(dialogToPlay);
            }
            else if (collision.gameObject.GetComponent<Rigidbody>())
            {
                levelManager.PlayDialog(dialogToPlay);
            }

            if (dialogTrigger  != null)
            {
                dialogTrigger.canPlay = true;
            }

            canPlay = false;
        }
    }
}
