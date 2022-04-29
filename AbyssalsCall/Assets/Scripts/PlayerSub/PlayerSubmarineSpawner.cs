using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubmarineSpawner : MonoBehaviour
{
    public static PlayerSubmarineSpawner Instance { get; private set;}

    [SerializeField]
    private PlayerSubmarine basicSubmarinePrefab;

    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }    
        Instance = this;
    }

    public PlayerSubmarine SpawnNewSubmarine()
    {
        PlayerSubmarine subInst = Instantiate<PlayerSubmarine>(basicSubmarinePrefab);
        SubmarineStateData subData = RunManager.Instance.ActivePlayerSubmarineStateData;

        foreach (string systemKey in subData.SystemStatesDict.Keys)
        {
            SystemBase instantiatedSystem = Instantiate(StringSystemConverter.Instance.StringToSystem(systemKey));
            instantiatedSystem.InitilizeSystem(subInst);
            instantiatedSystem.RegisterSystem();
        }

        return subInst;
    }

}
