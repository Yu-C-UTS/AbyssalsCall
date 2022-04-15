using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subgentest : MonoBehaviour
{
    [SerializeField]
    PlayerSubmarine baseSubmarinePrefab;
    
    [SerializeField]
    SystemBehaviorBase[] requiredSystems;

    private void Start() 
    {
        PlayerSubmarine instantiatedSub = Instantiate(baseSubmarinePrefab);

        foreach (SystemBehaviorBase system in requiredSystems)
        {
            SystemBehaviorBase instantiatedSystem = Instantiate(system);
            instantiatedSystem.InitilizeSystem(instantiatedSub);
            instantiatedSystem.RegisterSystem();
        }    

        CameraManager.Instance.MainFocusTransform = instantiatedSub.transform;
    }
}
