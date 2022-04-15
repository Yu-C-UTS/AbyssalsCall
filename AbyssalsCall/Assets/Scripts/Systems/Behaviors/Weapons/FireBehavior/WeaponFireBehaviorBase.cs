using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponFireBehaviorBase : WeaponBehaviorBase
{
    public abstract void Fire(Transform FirePoint, Vector2 FireDirection);
}
