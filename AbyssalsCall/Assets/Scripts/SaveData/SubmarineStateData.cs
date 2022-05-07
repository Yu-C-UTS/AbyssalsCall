using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(fileName = "NewDefaultSubmarineState", menuName = "ScriptableObjects/SubmarineStateData")]
public class SubmarineStateData : ScriptableObject
{
    [System.Serializable]
    public class SystemStatusDictionary : SerializableDictionaryBase<string, SystemStateData> {}


    public float MaxHealth = 100;
    public float CurrentHealth = 100;

    public string PrimWeapon = "BasicMG";
    public string SecWeapon;
    public SystemStatusDictionary SystemStatesDict;
}
