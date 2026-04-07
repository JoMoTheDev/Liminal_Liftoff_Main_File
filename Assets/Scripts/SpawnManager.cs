using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector3 currentSpawn;
    public Transform defaultSpawn;
    public static Transform currentCheckpoint;
    private GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentSpawn = new Vector3(defaultSpawn.position.x, defaultSpawn.position.y, defaultSpawn.position.z);
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
        player.SetActive(false);
        player.transform.position = currentSpawn;
        print("player is now at " + currentSpawn);
        player.SetActive(true);
    }

    void ResetCheckpoint()
    {
        currentSpawn = new Vector3(defaultSpawn.position.x, defaultSpawn.position.y, defaultSpawn.position.z);
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        currentSpawn = checkpointPosition;
    }
}
