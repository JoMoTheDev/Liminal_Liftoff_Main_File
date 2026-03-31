using UnityEngine;

public class BlasterSwitch : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;

    private MonoBehaviour[] blasterModes;

    private void Start()
    {
        blasterModes = new MonoBehaviour[]
        {
            playerCamera.GetComponent<BlasterGravity>(),
            playerCamera.GetComponent<BlasterLight>(),
            playerCamera.GetComponent<BlasterForce>(),
            playerCamera.GetComponent<BlasterShoot>()
        };
    }
    
    void ActivateModes(int index)
    {
        for (int i = 0; i < blasterModes.Length; i++)
            blasterModes[i].enabled = i == index;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ActivateModes(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ActivateModes(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ActivateModes(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) ActivateModes(3);
    }
}
