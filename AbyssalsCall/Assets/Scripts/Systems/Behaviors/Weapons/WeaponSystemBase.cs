using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSystemBase : SystemBase
{
    protected const float triggerThreshold = 0.7f;
    public abstract void TriggerBehavior(float triggerValue);

    public abstract Vector3 GetTargetLocation();
    public abstract Vector3 GetAimDirection();

    public override void RegisterSystem()
    {
        registeredSubmarine.onTriggerPrim += TriggerBehavior;
    }

    public override void UnRegisterSystem()
    {
        registeredSubmarine.onTriggerPrim -= TriggerBehavior;
    }
}
