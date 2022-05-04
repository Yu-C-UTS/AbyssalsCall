using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviorBase : MonoBehaviour
{
    public GeneralWeaponSystem parentWeaponSystem{ get; protected set;}
    public virtual void InitilizeBehavior(Transform WeaponTransform, GeneralWeaponSystem parentWeaponSystem)
    {
        this.parentWeaponSystem = parentWeaponSystem;
    }

    public virtual string[] GetStats()
    {
        return new string[0];
    }
}
