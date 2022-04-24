using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneController : SceneController
{
    public string SeedString = "HelloWorld";

    public void StartRun()
    {
        RunManager.Instance.NewRun(SeedString);
        GameSceneManager.Instance.LoadScene("MapDisplayScene");
    }

    public override void SetupScene()
    {
        Debug.Log("Nothing implimented");
    }
}
