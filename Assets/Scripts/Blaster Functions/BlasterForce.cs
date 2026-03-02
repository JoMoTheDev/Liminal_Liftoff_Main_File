using UnityEngine;

public class BlasterForce : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 10f;
    [SerializeField] private LayerMask collisionLayers;

    [SerializeField] private float launchForce = 15f;

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
                    Debug.Log("Begone!");

                    Rigidbody rb = hit.rigidbody;
                    rb.AddForce(direction * launchForce, ForceMode.Impulse);
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
