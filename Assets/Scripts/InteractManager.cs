using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public int keyAmount;
    public string keyTag, doorTag, simonTag;

    public void Interact(GameObject interactedObject) // this will need to be expanded later to accommodate the full game 
    {
        if (interactedObject.CompareTag(keyTag))
        {
            keyAmount += 1;
            interactedObject.SetActive(false);
            print(keyAmount);
        }

        if (interactedObject.GetComponent<LoadScene>() != null)
        {
            interactedObject.GetComponent<LoadScene>().SceneLoad();
        }

        if (interactedObject.GetComponent<PickupableObject>() != null)
        {
            interactedObject.GetComponent<PickupableObject>().ObjectCollected();
            interactedObject.SetActive(false);
        }

        if (interactedObject.CompareTag(doorTag) /*&& keyAmount >= 1*/)
        {
            keyAmount -= 1;
            interactedObject.SetActive(false);
            print(keyAmount);
        }
        else if (interactedObject.CompareTag(doorTag) && keyAmount < 1)
        {
            print("Door is locked");
        }

        if (interactedObject.CompareTag(simonTag))
        {
            interactedObject.GetComponent<PuzzleSimon>().ButtonPress();
        }
    }
}
