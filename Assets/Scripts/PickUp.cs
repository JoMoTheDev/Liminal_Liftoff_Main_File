using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
