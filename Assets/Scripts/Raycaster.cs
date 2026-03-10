using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour
{
    public float raycastDistance = 10f;

    public int keyAmount = 0;

    public LayerMask collisionLayers;
    public LayerMask interactLayer;

    private KeyManager keyManager;

    void Start()
    {
        keyManager = GetComponent<KeyManager>();
    }

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance, interactLayer))
            {
                keyManager.Interact(hit.transform.gameObject);
            }
        }
    }
}