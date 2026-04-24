using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private float raycastDistance = 10f;
    [SerializeField] private GameObject levelDoor;

    public int collectionMaxAmount;

    [SerializeField] private int collectionAmount = 0;

    private void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance, interactLayer))
            {
                // if (Note - likely checking for a tag)
                // {
                //      Check ID of note, or at least that's the best method I can think of
                //      Display relevant UI element
                // }
                collectionAmount++;
                Destroy(hit.collider.gameObject);
            }
        }

        if (collectionAmount == collectionMaxAmount)
        {
            if (levelDoor.GetComponent<Animation>() != null)
            {
                levelDoor.GetComponent<Animation>().enabled = true;
            }
            else
            {
                levelDoor.GetComponent<Collider>().isTrigger = true;
            }
        }
    }
}
