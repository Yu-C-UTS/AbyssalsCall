using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSystemBase : SystemBase
{
    protected const float triggerThreshold = 0.7f;
    public abstract void TriggerBehavior(float triggerValue);

    public abstract Transform GetTargetTransform();
    public abstract Vector3 GetAimDirection();

    protected bool IsPrimaryWeapon = true;

    public override void RegisterSystem()
    {
        RegisterSystem(true);
    }

    public virtual void RegisterSystem(bool PrimaryWeapon)
    {
        IsPrimaryWeapon = PrimaryWeapon;
        if(IsPrimaryWeapon)
        {
            registeredSubmarine.onTriggerPrim += TriggerBehavior;
        }
        else
        {
            registeredSubmarine.onTriggerSec += TriggerBehavior;
        }
    }

    public override void UnRegisterSystem()
    {
        if(IsPrimaryWeapon)
        {
            registeredSubmarine.onTriggerPrim -= TriggerBehavior;
        }
        else
        {
            registeredSubmarine.onTriggerSec -= TriggerBehavior;
        }
    }
}
