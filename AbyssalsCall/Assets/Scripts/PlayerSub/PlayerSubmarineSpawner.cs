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

        if(subData.PrimWeapon != "")
        {
            WeaponSystemBase instantiatedPrimWeapon = Instantiate(StringSystemConverter.Instance.StringToSystem(subData.PrimWeapon)) as WeaponSystemBase;
            if(instantiatedPrimWeapon == null)
            {
                Debug.LogError("Primary weapon instantiated but casting to weapon failed, might not be a weapon, aborting.");
            }
            else
            {
                instantiatedPrimWeapon.InitilizeSystem(subInst);
                instantiatedPrimWeapon.RegisterSystem(true);
            }
        }

        if(subData.SecWeapon != "")
        {
            WeaponSystemBase instantiatedSecWeapon = Instantiate(StringSystemConverter.Instance.StringToSystem(subData.SecWeapon)) as WeaponSystemBase;
            if(instantiatedSecWeapon == null)
            {
                Debug.LogError("Secondary weapon instantiated but casting to weapon failed, might not be a weapon, aborting.");
            }
            else
            {
                instantiatedSecWeapon.InitilizeSystem(subInst);
                instantiatedSecWeapon.RegisterSystem(false);
            }
        }

        return subInst;
    }

}
