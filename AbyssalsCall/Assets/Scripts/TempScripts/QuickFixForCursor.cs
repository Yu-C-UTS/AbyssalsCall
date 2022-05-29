using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class QuickFixForCursor : MonoBehaviour
{
    Scene currentScene;
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if(sceneName == "MapDisplayScene")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if(sceneName == "MenuScene")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
