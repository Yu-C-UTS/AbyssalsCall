using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class SceneController : MonoBehaviour
{
    protected virtual void Start() 
    {
        SetupScene();
    }

    //public UnityEvent OnPreSceneLoad;
    //public UnityEvent OnPostSceneLoad;

    public virtual void ReturnToMapDisplay()
    {
        GameSceneManager.Instance.LoadScene("MapDisplayScene");
    }

    public abstract void SetupScene();
}