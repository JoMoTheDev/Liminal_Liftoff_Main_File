using UnityEngine;

public class TutorialObjectTriggers : MonoBehaviour
{
    [Header("Function Selection")]
    public FunctionType functionType;
    public TutorialTriggers functionHandler;

    public enum FunctionType
    {
        None,
        PickUpBlaster
    }

    private void Update()
    {
        ExecuteFunction();   
    }

    private void ExecuteFunction()
    {
        switch (functionType)
        {
            case FunctionType.None:
                break;
            case FunctionType.PickUpBlaster:
                if (!gameObject.activeSelf)
                {
                    Debug.Log("Activate Blaster!");
                    functionHandler.BlasterDialogue();
                }
                break;
        }
    }
}
