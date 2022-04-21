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

    public void LoadScene(string SceneName)
    {
        Debug.Log("Loading Scene: " + SceneName);
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
    }

}
