using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int sceneToLoad;

    public void SceneLoad()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
