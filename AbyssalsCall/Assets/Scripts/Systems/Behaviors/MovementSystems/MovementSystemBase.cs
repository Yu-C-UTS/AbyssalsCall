using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementSystemBase : SystemBehaviorBase
{
    public abstract void MoveBehavior(Vector2 moveDirection);

    public override void RegisterSystem()
    {
        registeredSubmarine.onMove += MoveBehavior;
    }

    public override void UnRegisterSystem()
    {
        registeredSubmarine.onMove -= MoveBehavior;
    }
}
