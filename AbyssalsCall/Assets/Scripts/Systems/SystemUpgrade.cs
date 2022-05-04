using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SystemUpgrade
{
    public enum EUpgradeType
    { Continuous, Choice}

    [field: SerializeField]
    public EUpgradeType UpgradeType{ get; protected set;}

    [field: SerializeField]
    public string UpgradeName{ get; protected set;}

    
}
