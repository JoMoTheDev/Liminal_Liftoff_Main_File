using UnityEngine;

public class BlasterLight : MonoBehaviour
{
    public float raycastDistance = 10f;
    public LayerMask collisionLayers;
    public GameObject flashlight;

    private bool lightOn = false;

    void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            if (!lightOn)
            {
                lightOn = true;
                flashlight.SetActive(true);
            }
            else
            {
                lightOn = false;
                flashlight.SetActive(false);
            }
        }
        
        if (lightOn)
        {
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance, collisionLayers))
            {
                Debug.Log("This is where you should be looking!");
            }
        }
    }
}
