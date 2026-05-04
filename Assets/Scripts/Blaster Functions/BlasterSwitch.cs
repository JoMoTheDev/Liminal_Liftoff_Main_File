using UnityEngine;

public class BlasterSwitch : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;

    private MonoBehaviour[] blasterModes;

    public GameObject gravLight;
    public GameObject forceLight;
    public GameObject spotLight;

    private void Start()
    {
        blasterModes = new MonoBehaviour[]
        {
            playerCamera.GetComponent<BlasterLight>(),
            playerCamera.GetComponent<BlasterGravity>(),
            playerCamera.GetComponent<BlasterForce>()
            //playerCamera.GetComponent<BlasterShoot>()
        };

        ActivateModes(0);
        spotLight.SetActive(true);
    }
    
    void ActivateModes(int index)
    {
        for (int i = 0; i < blasterModes.Length; i++)
            blasterModes[i].enabled = i == index;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateModes(0);
            spotLight.SetActive(true);
            gravLight.SetActive(false);
            forceLight.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateModes(1);
            spotLight.SetActive(false);
            gravLight.SetActive(true);
            forceLight.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateModes(2);
            spotLight.SetActive(false);
            gravLight.SetActive(false);
            forceLight.SetActive(true);
        }
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    ActivateModes(3);
        //    gravLight.SetActive(false);
        //    forceLight.SetActive(false);
        //    spotLight.SetActive(true);
        //}
    }
}
