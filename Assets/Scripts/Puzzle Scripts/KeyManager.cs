using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public int keyAmount;
    public string keyTag, doorTag, simonTag;

    private int simonInt = 0;
    public string[] simonCode;

    public void Interact(GameObject interactedObject) // this will need to be expanded later to accommodate the full game 
    {
        if (interactedObject.CompareTag(keyTag))
        {
            keyAmount += 1;
            Destroy(interactedObject);
            print(keyAmount);
        }

        if (interactedObject.CompareTag(doorTag) && keyAmount >= 1)
        {
            keyAmount -= 1;
            Destroy(interactedObject);
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

    public void SolveSimon(string buttonColor)
    {
        if (buttonColor == simonCode[simonInt] && simonInt == (simonCode.Length - 1))
        {
            print("solved");
        }
        else if (buttonColor == simonCode[simonInt])
        {
            print("correct " + simonCode[simonInt]);
            simonInt += 1;
        }
        else
        {
            print("wrong " + simonCode[simonInt]);
            simonInt = 0;
        }
    }
}
