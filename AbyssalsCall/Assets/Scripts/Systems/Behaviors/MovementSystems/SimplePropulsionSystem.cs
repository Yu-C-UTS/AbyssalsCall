using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePropulsionSystem : MovementSystemBase
{
    [SerializeField]
    float propulsionForce = 10f;
    float currentMoveForce = 0f;

    public override void MoveBehavior(Vector2 moveDirection)
    {
        currentMoveForce = moveDirection.x * propulsionForce;
    }

    public void SystemFixedUpdate()
    {
        registeredSubmarine.rigidBody2d.AddForce(new Vector2(currentMoveForce, 0));
    }

    public override void RegisterSystem()
    {
        base.RegisterSystem();
        registeredSubmarine.onSubFixedUpdate += SystemFixedUpdate;
    }

    public override void UnRegisterSystem()
    {
        base.UnRegisterSystem();
        registeredSubmarine.onSubFixedUpdate -= SystemFixedUpdate;
    }

}
