using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector3 currentSpawn;
    private Transform defaultSpawn;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Target");
        }
        GameObject defaultSpawnObject = GameObject.Find("DefaultSpawn");
        defaultSpawn = defaultSpawnObject.transform;
        currentSpawn = defaultSpawn.position;
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
        player.transform.position = currentSpawn;
        //player.transform.rotation = 
        player.SetActive(true);
        print("loaded check point @ " +  currentSpawn);
    }

    void ResetCheckpoint()
    {
        currentSpawn = defaultSpawn.position;
    }
}
