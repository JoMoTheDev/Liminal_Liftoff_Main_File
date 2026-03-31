using UnityEngine;

public class BlasterPickup : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    public Transform holdPosition;
    public LayerMask collisionLayers;
    private PlayerController playerController;
    private GameObject heldObject;
    private Rigidbody heldObjectRb;

    [Header("Values")]
    public float raycastDistance = 10f;
    private bool canDrop = true;
    private int LayerNumber; //Layer index

    private void Start()
    {
        LayerNumber = LayerMask.NameToLayer("HoldLayer");
        
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null) //If currently not holding anything
            {
                if (Physics.Raycast(transform.position, direction, out hit, raycastDistance, collisionLayers))
                {
                    //Make sure pickup tag is assigned
                    if (hit.transform.gameObject.tag == "canPickUp")
                    {
                        Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow);
                        Debug.Log("That thing is " + hit.distance + " meters away!");

                        //Pass in object hit in the PickUpObject function
                        PickUpObject(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                if (canDrop == true)
                {
                    Debug.DrawRay(transform.position, direction * raycastDistance, Color.red);
                    Debug.Log("Nothing here!");

                    StopClipping();
                    DropObject();
                }
            }
        }
        if (heldObject != null)
        {
            MoveObject();
            if (Input.GetMouseButtonDown(1) && canDrop == true)
            {
                StopClipping();
            }
        }
    }

    private void PickUpObject(GameObject pickUpObject)
    {
        if (pickUpObject.GetComponent<Rigidbody>()) //Make sure the object has a RigidBody
        {
            heldObject = pickUpObject; //Assign the heldObject variable to the object hit by the Raycast
            heldObjectRb = pickUpObject.GetComponent<Rigidbody>(); //Assign the Rigidbody variable
            heldObjectRb.isKinematic = true;
            heldObjectRb.transform.parent = holdPosition.transform; //Parent Object to HoldPosition
            heldObject.layer = LayerNumber; //Change the object layer to HoldLayer
            //Make sure the object doesn't collide with the player
            Physics.IgnoreCollision(heldObject.GetComponent<Collider>(), player.GetComponentInChildren<Collider>(), true);
        }
    }

    private void DropObject()
    {
        //Re-enable object collisions
        Physics.IgnoreCollision(heldObject.GetComponent<Collider>(), player.GetComponentInChildren<Collider>(), false);
        heldObject.layer = 0; //Assign object to default layer
        heldObjectRb.isKinematic = false;
        heldObject.transform.parent = null; //Unparent the object
        heldObject = null; //Undefine the object
    }

    private void MoveObject()
    {
        //Keep the Object locked at HoldPosition
        heldObject.transform.localPosition = Vector3.zero;
    }

    private void StopClipping() //Function called with dropping/throwing object
    {
        var clipRange = Vector3.Distance(heldObject.transform.position, transform.position); //Distance from HoldPosition to the camera
        //RaycastAll is necessary as the object blocks the center raycast
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        //If the array length is greater than 1, meaning it has hit more than the object we're carrying
        if (hits.Length > 1)
        {
            //Change object position to camera position
            heldObject.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); //Offset slightly downward to keep the object from dropping above the player
        }
    }
}
