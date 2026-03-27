using UnityEngine;

public class BlasterGravity : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;
    public Transform holdPoint;

    [Header("Pickup Settings")]
    public float raycastRange = 10f;
    public float moveForce = 150f;
    public LayerMask pickupLayer;

    private Rigidbody heldObject;
    private float holdDistance;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null)
            {
                TryPickUp();
            }
            else
            {
                DropObject();
            }
        }

        if (heldObject != null)
        {
            MoveObject();
        }
    }

    private void TryPickUp()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, raycastRange, pickupLayer))
        {
            Rigidbody rb = hit.rigidbody;

            if (rb != null)
            {
                heldObject = rb;
                heldObject.useGravity = false;
                heldObject.linearDamping = 10;

                holdDistance = Vector3.Distance(playerCamera.transform.position, hit.point);
            }
        }
    }

    private void MoveObject()
    {
        Vector3 targetPosition = playerCamera.transform.position + playerCamera.transform.forward * holdDistance;

        Vector3 direction = targetPosition - heldObject.position;

        heldObject.linearVelocity = direction * moveForce * Time.deltaTime;
    }

    private void DropObject()
    {
        heldObject.useGravity = true;
        heldObject.linearDamping = 0;
        heldObject = null;
    }
}
