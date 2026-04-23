using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int sceneToLoad;
    public bool isPassive;

    public void SceneLoad()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isPassive && collision.gameObject.CompareTag("Target") || collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
