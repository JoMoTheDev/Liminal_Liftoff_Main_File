using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private SpawnManager CMRef;
    private void Start()
    {
        CMRef = FindFirstObjectByType<SpawnManager>();
    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            CMRef.currentSpawn = transform.position;
            print("set checkpoint @ " + transform.position);
        }
    }
}
