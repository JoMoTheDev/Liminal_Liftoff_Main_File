using UnityEngine;

public class PuzzleSimon : MonoBehaviour
{
    public string buttonColor;

    public SimonManager simonManager;

    public void ButtonPress()
    {
        simonManager.SolveSimon(buttonColor);
    }
}
