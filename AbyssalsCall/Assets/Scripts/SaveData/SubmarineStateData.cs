using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(fileName = "NewDefaultSubmarineState", menuName = "ScriptableObjects/SubmarineStateData")]
public class SubmarineStateData : ScriptableObject
{
    [System.Serializable]
    public class SystemStatusDictionary : SerializableDictionaryBase<string, SystemStateData> {}


    public SystemStatusDictionary SystemStatesDict;
}
