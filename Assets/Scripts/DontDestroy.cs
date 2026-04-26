using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] persisentObjects = new GameObject[3];

    public int objectIndex;

    void Awake()
    {
        if (persisentObjects[objectIndex] == null)
        {
            persisentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (persisentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject);
        }
    }
}
