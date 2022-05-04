using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
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

    private void Start() 
    {
        if(UnityEngine.SceneManagement.SceneManager.sceneCount <= 1)
        {
            GameSceneManager.Instance.LoadScene("MenuScene");
        }       
    }

    public void LoadScene(string SceneName)
    {
        Debug.Log("Loading Scene: " + SceneName);
    }

    public void SceneLoaded()
    {
        Debug.Log("Scene loaded message recieved");
    }
}
