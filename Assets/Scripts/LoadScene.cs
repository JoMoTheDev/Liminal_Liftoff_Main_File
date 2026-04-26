using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int sceneToLoad;

    public void SceneLoad()
    {
        Debug.Log("Load!");
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door") && other.gameObject.TryGetComponent(out DoorID doorID))
        {
            Debug.Log("Here is a door!");
            if (doorID != null)
            {
                Debug.Log("The next scene will be " + doorID.targetScene);
                sceneToLoad = doorID.targetScene;
                SceneLoad();
            }
        }
    }
}
