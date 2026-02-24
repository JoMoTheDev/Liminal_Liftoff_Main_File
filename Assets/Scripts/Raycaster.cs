using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public float raycastDistance = 10f;
    public LayerMask collisionLayers;

    private void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance, collisionLayers))
            {
                Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow);
                Debug.Log("That thing is " + hit.distance + " meters away!");
            }
            else
            {
                Debug.DrawRay(transform.position, direction * raycastDistance, Color.red);
                Debug.Log("Nothing here!");
            }
        }
    }
}
