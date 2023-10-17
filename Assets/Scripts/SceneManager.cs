using System.Collections;

using System.Diagnostics;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void Play()
    {
        StartCoroutine(LoadLevelAsync(2));
    }
    public void Quit()
    {
        Application.Quit();
    }


    public static IEnumerator LoadLevelAsync(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");


        AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        UnityEngine.Debug.Log("loading");

        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            UnityEngine.Debug.Log(asyncOperation.progress);
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
        
    }

    public static IEnumerator LoadLevelAsync(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");
        
        AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
        asyncOperation.allowSceneActivation = false;
        UnityEngine.Debug.Log("loading");
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
        
    }

}
