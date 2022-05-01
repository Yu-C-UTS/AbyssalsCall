using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance;

    [SerializeField]
    private RunGenerationData runGenerationData;

    //[Space(20)]

    public run activeRun{ get; private set;}

    [field: SerializeField]
    public SubmarineStateData ActivePlayerSubmarineStateData{ get; private set;}

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

    public void SaveRun()
    {
        Debug.Log("Save feature not implimented yet.");
    }

    public void LoadRun()
    {
        Debug.Log("Load feature not implimented yet.");
    }
}
