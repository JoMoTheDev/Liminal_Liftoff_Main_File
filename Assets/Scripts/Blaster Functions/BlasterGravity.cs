using UnityEngine;

public class BlasterGravity : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 10f;
    [SerializeField] private LayerMask collisionLayers;

    void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance, collisionLayers))
            {
                if (hit.rigidbody != null)
                {
                    Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow);

                    Rigidbody rb = hit.rigidbody;

                    if (!rb.useGravity)
                    {
                        rb.useGravity = true;
                        Debug.Log("To the Ground with ye!");
                    }
                    else
                    {
                        rb.useGravity = false;
                        Debug.Log("To the Sky with ye!");
                    }
                }
                else
                {
                    Debug.DrawRay(transform.position, direction * raycastDistance, Color.red);
                    Debug.Log("Immovable Object!");
                }
            }
            else
            {
                Debug.DrawRay(transform.position, direction * raycastDistance, Color.red);
                Debug.Log("Nothing here!");
            }
        }
    }
}
