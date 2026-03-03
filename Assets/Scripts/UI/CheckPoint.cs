using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPointManager CMRef;
    private void Start()
    {
        CMRef = FindFirstObjectByType<CheckPointManager>();
    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision");
            CMRef.currentSpawn = transform.position;
        }
    }
}
