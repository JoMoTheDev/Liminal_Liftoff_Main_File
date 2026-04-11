using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector3 currentSpawn;
    public Transform defaultSpawn;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentSpawn = defaultSpawn.position;
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
        player.SetActive(true);
        print("loaded check point @ " +  currentSpawn);
    }

    void ResetCheckpoint()
    {
        currentSpawn = defaultSpawn.position;
    }
}
