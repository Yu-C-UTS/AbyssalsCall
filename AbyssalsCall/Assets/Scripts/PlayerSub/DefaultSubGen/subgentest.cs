using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subgentest : MonoBehaviour
{
    [SerializeField]
    PlayerSubmarine baseSubmarinePrefab;
    
    [SerializeField]
    SystemBase[] requiredSystems;

    private void Start() 
    {
        PlayerSubmarine instantiatedSub = Instantiate(baseSubmarinePrefab);

        foreach (SystemBase system in requiredSystems)
        {
            SystemBase instantiatedSystem = Instantiate(system);
            instantiatedSystem.InitilizeSystem(instantiatedSub);
            instantiatedSystem.RegisterSystem();
        }    

        CameraManager.Instance.MainFocusTransform = instantiatedSub.transform;
    }
}
