using System.Collections;
using UnityEngine;

public class TutorialTriggers : MonoBehaviour
{
    public GameObject blasterVisual;
    //public GameObject noteOne;
    //public GameObject mapItem;
    //public GameObject stickyNote;
    //public GameObject shipWindow;
    //public GameObject shipFins;
    //public GameObject playerLight;
    //public GameObject noteTwo;

    //public Transform playerRef;
    //public GameObject playerCamera;

    //private bool flashlightActivated = false;

    //private void Update()
    //{
    //    if (blasterItem == null)
    //    {
    //        blasterVisual.SetActive(true);
    //        //Play dialogue
    //    }

    //    //if (mapItem == null)
    //    //{
    //    //    Display map on heads up display
    //    //}

    //    //if (stickyNote == null)
    //    //{
    //    //    Play dialogue
    //    //}

    //    //if (shipWindow == null)
    //    //{
    //    //    Play dialogue
    //    //}

    //    //if (shipFins == null)
    //    //{
    //    //    Play dialogue
    //    //}

    //    //if (playerLight && flashlightActivated == false)
    //    //{
    //    //    Play dialogue
    //    //}
    //}

    public void BlasterDialogue()
    {
        blasterVisual.SetActive(true);
        //Play Dialogue after the player picks up the blaster
    }

    IEnumerator TalkingDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
