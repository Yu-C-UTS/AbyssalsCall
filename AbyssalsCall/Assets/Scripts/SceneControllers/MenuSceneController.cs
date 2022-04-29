using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneController : SceneController
{
    public string SeedString = "HelloWorld";

    public void StartRun()
    {
        SetupRun();
        //GameSceneManager.Instance.LoadScene("EnemyTestScene");
        GameSceneManager.Instance.LoadScene("MapDisplayScene");
    }

    public void SetNewSeedString(string newSeedString)
    {
        SeedString = newSeedString;
    }

    public override void SetupScene()
    {
        Debug.Log("Nothing implimented");
    }

    public void SetupRun()
    {
        RunManager.Instance.NewRun(SeedString);
    }
}
