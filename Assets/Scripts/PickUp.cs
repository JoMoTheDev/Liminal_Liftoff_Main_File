using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private float raycastDistance = 10f;
    [SerializeField] private GameObject levelDoor;

    public int collectionMaxAmount;

    private int collectionAmount;

    private void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance, interactLayer))
            {
                Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow);
                Debug.Log("That thing is " + hit.distance + " meters away!");
            }
        }
    }
}
