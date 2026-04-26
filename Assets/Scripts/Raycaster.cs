using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour
{
    public float raycastDistance = 10f;

    public LayerMask collisionLayers;
    public LayerMask interactLayer;

    private InteractManager interactManager;

    void Start()
    {
        interactManager = GetComponent<InteractManager>();
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        if (/*Input.GetMouseButtonDown(1)*/ Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance))
            {
                interactManager.Interact(hit.transform.gameObject);
                Debug.DrawRay(transform.position, direction * raycastDistance, Color.blue);
            }
        }
    }
}
