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
}
