using UnityEngine;

public class BlasterLight : MonoBehaviour
{
    public float raycastDistance = 10f;
    public LayerMask collisionLayers;
    public GameObject flashlight;
    public ParticleSystem lightParticles;

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
                lightParticles.Play();
            }
            else
            {
                lightOn = false;
                flashlight.SetActive(false);
                lightParticles.Stop();
            }
        }
    }
}
