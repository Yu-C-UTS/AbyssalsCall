using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance;

    [SerializeField]
    private RunGenerationData runGenerationData;

    private run activeRun;

    private void Awake() 
    {
        if(Instance != null)
        {
            Debug.LogWarning("A run manager already exist, destroying self.");
            Destroy(this);
            return;
        }    
        Instance = this;
        //DontDestroyOnLoad(this);
    }
    
    public void NewRun(string seed)
    {
        activeRun = new run(seed);
        activeRun.InitilizeRun(runGenerationData);
    }

    public void StepRun(int nodeInt)
    {
        activeRun.StepRun(nodeInt);
    }

    public zone GetCurrentZone()
    {
        return activeRun.GetCurrentZone();
    }

    public layer GetCurrentLayer()
    {
        return activeRun.GetCurrentLayer();
    }

    public node GetLatestActiveNode()
    {
        return activeRun.GetLatestActiveNode();
    }

    public void SaveRun()
    {
        Debug.Log("Save feature not implimented yet.");
    }

    public void LoadRun()
    {
        Debug.Log("Load feature not implimented yet.");
    }
}
