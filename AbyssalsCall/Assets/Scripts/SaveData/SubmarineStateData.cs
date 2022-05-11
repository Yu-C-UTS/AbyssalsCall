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
    [SerializeField]
    private float _currentHealth = 100;
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

    public string PrimWeapon = "BasicMG";
    public string SecWeapon;
    public SystemStatusDictionary SystemStatesDict;

    public bool ReplacePrimWeapon(string NewPrimWeaponKey)
    {
        if(StringSystemConverter.Instance.StringToSystem(NewPrimWeaponKey) != null)
        {
            PrimWeapon = NewPrimWeaponKey;
            return true;
        }
        return false;
    }

    public bool ReplaceSecWeapon(string NewSecWeaponKey)
    {
        if(StringSystemConverter.Instance.StringToSystem(NewSecWeaponKey) != null)
        {
            SecWeapon = NewSecWeaponKey;
            return true;
        }
        return false;
    }
}
