using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform currentSpawn;
    private Transform defaultSpawn;
    private GameObject player;
    private PlayerController playerController;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Target");
        }
        playerController = player.GetComponent<PlayerController>();
        GameObject defaultSpawnObject = GameObject.Find("DefaultSpawn");
        defaultSpawn = defaultSpawnObject.transform;
        currentSpawn = defaultSpawn;
    }

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
        player.SetActive(false);
        player.transform.position = currentSpawn.position;
        player.transform.rotation = currentSpawn.rotation;
        playerController.SetRotation(currentSpawn.rotation);
        player.SetActive(true);
        print("loaded check point @ " +  currentSpawn);
    }

    void ResetCheckpoint()
    {
        currentSpawn = defaultSpawn;
    }
}
