using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneController : SceneController
{
    public void StartRun()
    {
        //RunManager.Instance.NewRun("Randomer");
        GameSceneManager.Instance.LoadScene("FullRunMapTestScene");
    }

    public override void SetupScene()
    {
        Debug.Log("Nothing implimented");
    }
}
