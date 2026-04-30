using UnityEngine;

public class PuzzleSimon : MonoBehaviour
{
    public string buttonColor;

    private InteractManager interactManager;

    void Start()
    {
        interactManager = FindFirstObjectByType<InteractManager>();
    }

    public void ButtonPress()
    {
        interactManager.SolveSimon(buttonColor);
    }
}
