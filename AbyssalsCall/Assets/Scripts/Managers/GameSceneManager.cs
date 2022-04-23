using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private static GameSceneManager _instance;
    public static GameSceneManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private Scene latestActiveScene;

    private void Awake() 
    {
        if(_instance != null)
        {
            Destroy(this);
            return;
        }    
        _instance = this;
        //DontDestroyOnLoad(this);
    }

    private void Start() 
    {
        SceneManager.sceneLoaded += ChangeActiveScene;
    }

    public void LoadScene(string SceneName)
    {
        Debug.Log("Loading Scene: " + SceneName);
        AsyncOperation asyncLoadScene = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
    }

    public void ChangeActiveScene(Scene newActiveScene, LoadSceneMode loadSceneMode)
    {
        Debug.Log("Scene load detected");
        if(latestActiveScene.name != null)
        {
            SceneManager.UnloadSceneAsync(latestActiveScene);
        }

        latestActiveScene = newActiveScene;
    }
}
