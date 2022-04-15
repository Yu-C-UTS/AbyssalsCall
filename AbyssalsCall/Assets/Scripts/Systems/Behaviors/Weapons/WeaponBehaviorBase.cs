using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviorBase : ScriptableObject
{
    public GeneralWeaponSystem parentWeaponSystem{ get; protected set;}
    public virtual void InitilizeBehavior(Transform WeaponTransform, GeneralWeaponSystem parentWeaponSystem)
    {
        this.parentWeaponSystem = parentWeaponSystem;
    }
}
