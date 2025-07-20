using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadScript : MonoBehaviour
{
    public float waitTime = 1f;
    public GameEvent sceneResetEvent;

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadSceneDelay()
    {
        sceneResetEvent.TriggerEvent();
        StartCoroutine(SceneLoadDelay());
    }

    private IEnumerator SceneLoadDelay()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);  //assumes this scene is the first one
    }
}