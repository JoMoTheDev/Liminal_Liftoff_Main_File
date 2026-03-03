using UnityEngine;

public class BlasterSwitch : MonoBehaviour
{
    private BlasterShoot blasterShoot;
    private BlasterGravity blasterGravity;
    private BlasterForce blasterForce;
    private BlasterGrab blasterGrab;
    public GameObject playerCamera;
    public blasterState state;

    public enum blasterState
    {
        Shoot,
        Gravity,
        Grab,
        Force
    }

    private void Start()
    {
        blasterShoot = playerCamera.GetComponent<BlasterShoot>();
        blasterGravity = playerCamera.GetComponent<BlasterGravity>();
        blasterForce = playerCamera.GetComponent<BlasterForce>();
        blasterGrab = playerCamera.GetComponent<BlasterGrab>();
    }

    private void Update()
    {
        StateSwitch();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = blasterState.Shoot;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = blasterState.Gravity;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            state = blasterState.Grab;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            state = blasterState.Force;
        }
    }

    public void StateSwitch()
    {
        switch (state)
        {
            case blasterState.Shoot:
                break;
            case blasterState.Gravity:
                break;
            case blasterState.Grab:
                break;
            case blasterState.Force:
                break;
        }
    }
}
