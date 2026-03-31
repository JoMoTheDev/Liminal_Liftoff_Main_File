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
            Debug.Log("Collision");
            CMRef.currentSpawn = transform.position;
            PlayerPrefs.SetFloat("xPos", transform.position.x);
            PlayerPrefs.SetFloat("yPos", transform.position.y);
            PlayerPrefs.SetFloat("zPos", transform.position.z);
        }
    }
}