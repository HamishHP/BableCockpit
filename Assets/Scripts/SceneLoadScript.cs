using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadScript : MonoBehaviour
{
    public float waitTime = 1f;
    public GameEvent sceneResetEvent;

    public void PlayGameScene() 
    {
        SceneManager.LoadScene(1);  //assumes game scene is 1
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReloadSceneDelay()
    {
        sceneResetEvent.TriggerEvent();
        StartCoroutine(SceneLoadDelay());
    }

    private IEnumerator SceneLoadDelay()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }
}