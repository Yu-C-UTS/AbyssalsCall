using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public Damage(float BaseValue)
    {
        _baseValue = BaseValue;
    }

    private float _baseValue;

    public float BaseValue
    {
        get
        {
            return _baseValue;
        }
        set
        {
            _baseValue = value;
        }
    }
}
