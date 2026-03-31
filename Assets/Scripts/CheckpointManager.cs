using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Vector3 currentSpawn;
    public Transform defaultSpawn;
    public static Transform currentCheckpoint;
    public GameObject player;


    void Start()
    {
        LoadCheckpoint();
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            ResetCheckpoint();
        }

        if (Input.GetKeyDown("l"))
        {
            LoadCheckpoint();
        }
    }

    void LoadCheckpoint()
    {
        Vector3 tempSpawn = new Vector3(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"), PlayerPrefs.GetFloat("zPos"));
        player.transform.position = tempSpawn;
    }

    void ResetCheckpoint()
    {
        PlayerPrefs.SetFloat("xPos", defaultSpawn.position.x);
        PlayerPrefs.SetFloat("yPos", defaultSpawn.position.y);
        PlayerPrefs.SetFloat("zPos", defaultSpawn.position.z);

    }
}
