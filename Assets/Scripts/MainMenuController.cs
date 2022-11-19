using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void onLoadSceneButtonPressed(int sceneId)
    {
        Debug.Log("Loading scene " + sceneId + "...");
        SceneManager.LoadScene(sceneId);
    }

    public void onLoadSceneButtonPressed(string sceneName)
    {
        Debug.Log("Loading " + sceneName + " scene...");
        SceneManager.LoadScene(sceneName);
    }
}
