using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Damage
{
    public Damage(float BaseDamageValue)
    {
        baseDamageValue = BaseDamageValue;
    }

    [field: SerializeField]
    public float baseDamageValue{ get; private set;}

    public void OverrideBaseDamageValue(float newValue)
    {
        baseDamageValue = newValue;
    }
}
