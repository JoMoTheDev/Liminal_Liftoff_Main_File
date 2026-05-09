using Unity.Jobs;
using UnityEngine;

public class BlasterGravity : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;
    public Transform holdPoint;
    [SerializeField] private AudioSource gravPickUpSFX;
    [SerializeField] private AudioSource gravDropSFX;

    [Header("Pickup Settings")]
    public float raycastRange = 10f;
    public float moveForce = 150f;
    public LayerMask pickupLayer;
    public ParticleSystem gravParticles;

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
            gravParticles.Play();

            if (rb != null)
            {
                heldObject = rb;

                if (rb.CompareTag("Free") || rb.CompareTag("Note"))
                {
                    rb.constraints = RigidbodyConstraints.None;
                }

                heldObject.useGravity = false;
                heldObject.linearDamping = 10;
                gravPickUpSFX.Play();

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
        if (heldObject.CompareTag("Lego"))
        {
            heldObject.linearDamping = 0;
            heldObject = null;
            gravParticles.Stop();
        }
        else
        {
            heldObject.useGravity = true;
            heldObject.linearDamping = 0;
            heldObject = null;
            gravParticles.Stop();
        }
        gravDropSFX.Play();
    }
}
