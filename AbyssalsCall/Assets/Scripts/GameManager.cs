using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager _instance;
    public GameManager Instance
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
        }    
        _instance = this;
        DontDestroyOnLoad(this);
    }
}
