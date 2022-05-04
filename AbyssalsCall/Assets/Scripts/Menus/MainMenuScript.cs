using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public string NewRunSeed;

    private void Start() 
    {
        NewRunSeed = Random.Range(0, int.MaxValue).ToString();
    }
    
    public void ChangeNewRunSeed(string seedText)
    {
        NewRunSeed = seedText;
    }

    public void CreateAndStartNewRun()
    {
        RunManager.Instance.NewRun(NewRunSeed);
    }
}
