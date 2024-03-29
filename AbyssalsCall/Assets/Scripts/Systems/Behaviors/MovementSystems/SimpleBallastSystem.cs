using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBallastSystem : MovementSystemBase
{
    [SerializeField]
    float ballastForce = 5f;
    float currentMoveForce = 0f;

    public override void MoveBehavior(Vector2 moveDirection)
    {
        currentMoveForce = moveDirection.y * ballastForce;
    }

    public void SystemFixedUpdate()
    {
        registeredSubmarine.rigidBody2d.AddForce(new Vector2(0, currentMoveForce));
    }

    public override void RegisterSystem()
    {
        base.RegisterSystem();
        registeredSubmarine.onSubFixedUpdate.AddListener(SystemFixedUpdate);
    }

    public override void UnRegisterSystem()
    {
        base.UnRegisterSystem();
        registeredSubmarine.onSubFixedUpdate.RemoveListener(SystemFixedUpdate);
    }

}
