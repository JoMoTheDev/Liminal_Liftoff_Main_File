using System.Collections;
using UnityEngine;

public class TutorialTriggers : MonoBehaviour
{
    [SerializeField] private GameObject blasterItem;
    [SerializeField] private GameObject blasterVisual;
    [SerializeField] private GameObject noteOne;
    [SerializeField] private GameObject mapItem;
    [SerializeField] private GameObject stickyNote;
    [SerializeField] private GameObject shipWindow;
    [SerializeField] private GameObject shipFins;
    [SerializeField] private GameObject noteTwo;

    [SerializeField] private Transform playerRef;
    [SerializeField] private GameObject playerCamera;



    IEnumerator TalkingDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
