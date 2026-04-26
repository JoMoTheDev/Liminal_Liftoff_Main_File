using UnityEngine;

public class BlasterShoot : MonoBehaviour
{
    public float raycastDistance = 10f;
    public string enemyTag;
    public LayerMask objectShootLayer;
    [SerializeField] private int blasterDamage = 50;

    private void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance, objectShootLayer))
            {
                Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow);
                Debug.Log("Target took " + blasterDamage + " damage!" );

                if (hit.collider.gameObject.CompareTag("Note"))
                {
                    Rigidbody rb = hit.rigidbody;

                    hit.collider.gameObject.layer = LayerMask.NameToLayer("InteractLayer");

                    rb.useGravity = true;
                    rb.constraints = RigidbodyConstraints.None;
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
