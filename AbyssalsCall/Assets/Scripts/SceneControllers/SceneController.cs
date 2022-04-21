using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneController : MonoBehaviour
{
    protected virtual void Start() 
    {
        GameManager.Instance.SceneLoaded();   
    }

    public abstract void LoadScene();
}
