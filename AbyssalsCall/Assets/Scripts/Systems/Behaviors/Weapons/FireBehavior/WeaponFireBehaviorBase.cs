using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponFireBehaviorBase : WeaponBehaviorBase
{
    public enum FireDirection
    { forward = Directions.EDirection.forward, backward = Directions.EDirection.backward, upward = Directions.EDirection.upward, downward = Directions.EDirection.downward, turret}

    public FireDirection WeaponFireDirection = FireDirection.forward;

    public abstract void Fire();

    protected Vector3 getFireDirectionVector()
    {   
        switch(WeaponFireDirection)
        {
            case FireDirection.forward:
            case FireDirection.backward:
            case FireDirection.upward:
            case FireDirection.downward:
            return Directions.RelativeDirectionToV3((Directions.EDirection)(int)WeaponFireDirection, parentWeaponSystem.firePoint);

            case FireDirection.turret:
            return parentWeaponSystem.GetAimDirection();

            default:
            Debug.LogWarning("Unknow Fire Direction, returning forward");
            return parentWeaponSystem.firePoint.TransformDirection(parentWeaponSystem.firePoint.right);
        }
    }
}
