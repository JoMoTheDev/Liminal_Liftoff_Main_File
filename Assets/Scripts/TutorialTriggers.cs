using System.Collections;
using UnityEngine;

public class TutorialTriggers : MonoBehaviour
{
    [SerializeField] private GameObject blasterItem;
    [SerializeField] private GameObject blasterVisual;
    [SerializeField] private GameObject noteOne;
    //[SerializeField] private GameObject mapItem;
    //[SerializeField] private GameObject stickyNote;
    [SerializeField] private GameObject shipWindow;
    [SerializeField] private GameObject shipFins;
    [SerializeField] private GameObject playerLight;
    [SerializeField] private GameObject noteTwo;

    [SerializeField] private Transform playerRef;
    [SerializeField] private GameObject playerCamera;

    private bool flashlightActivated = false;

    //private void Start()
    //{
    //    Play starting dialogue
    //}

    private void Update()
    {
        if (blasterItem == null)
        {
            blasterVisual.SetActive(true);
            //Play dialogue
        }

        if (noteOne.GetComponent<Rigidbody>().useGravity)
        {
            noteOne.layer = LayerMask.NameToLayer("InteractLayer");
            //Play dialogue
        }

        //if (mapItem == null)
        //{
        //    Display map on heads up display
        //}

        //if (stickyNote == null)
        //{
        //    Play dialogue
        //}

        //if (shipWindow == null)
        //{
        //    Play dialogue
        //}

        //if (shipFins == null)
        //{
        //    Play dialogue
        //}

        //if (playerLight && flashlightActivated == false)
        //{
        //    Play dialogue
        //}
    }

    IEnumerator TalkingDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
