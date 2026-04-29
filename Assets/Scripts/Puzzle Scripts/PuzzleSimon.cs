using UnityEngine;

public class PuzzleSimon : MonoBehaviour
{
    public string buttonColor;

    private KeyManager keyManager;

    void Start()
    {
        keyManager = FindFirstObjectByType<KeyManager>();
    }

    public void ButtonPress()
    {
        keyManager.SolveSimon(buttonColor);
    }
}
