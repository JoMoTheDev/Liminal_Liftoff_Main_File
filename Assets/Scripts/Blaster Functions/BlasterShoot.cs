using UnityEngine;

public class BlasterShoot : MonoBehaviour
{
    public float raycastDistance = 10f;
    public LayerMask enemyLayers;
    [SerializeField] private int blasterDamage = 50;

    private void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance, enemyLayers))
            {
                Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow);
                Debug.Log("Target took " + blasterDamage + " damage!" );
            }
            else
            {
                Debug.DrawRay(transform.position, direction * raycastDistance, Color.red);
                Debug.Log("Nothing here!");
            }
        }
    }
}
