using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponTriggerBehaviorBase : WeaponBehaviorBase
{
    protected const float triggerThreshold = 0.7f;

    public abstract void triggerBehavior(float triggerValue);
}
