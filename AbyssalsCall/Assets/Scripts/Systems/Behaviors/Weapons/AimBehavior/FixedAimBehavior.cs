using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFixedAimBehavior", menuName = "ScriptableObjects/WeaponBehavior/AimBehavior/FixedAimBehavior")]
public class FixedAimBehavior : WeaponAimBehaviorBase
{
    public enum FireDirection
    { forward, backward, upward, downward}

    public FireDirection WeaponFireDirection = FireDirection.forward;
    public float AimReticleRange = 5f;

    public override void AimUpdate()
    {
        RaycastHit2D cast = Physics2D.CircleCast(parentWeaponSystem.firePoint.position, 0.5f, GetFireDirection(), AimReticleRange);
        if(cast.transform != null)
        {
            crosshairTransform.SetPositionAndRotation(cast.point, Quaternion.identity);
        }
        else
        {
            crosshairTransform.SetPositionAndRotation(parentWeaponSystem.firePoint.position + (Vector3)GetFireDirection() * AimReticleRange, Quaternion.identity);
        }
    }

    public override Vector2 GetFireDirection()
    {
        switch (WeaponFireDirection)
        {
            case FireDirection.forward:
            return parentWeaponSystem.firePoint.TransformDirection(parentWeaponSystem.firePoint.right);

            case FireDirection.backward:
            return parentWeaponSystem.firePoint.TransformDirection(-parentWeaponSystem.firePoint.right);

            case FireDirection.upward:
            return parentWeaponSystem.firePoint.TransformDirection(parentWeaponSystem.firePoint.up);

            case FireDirection.downward:
            return parentWeaponSystem.firePoint.TransformDirection(-parentWeaponSystem.firePoint.up);

            default:
            Debug.LogWarning("Unknow Fire Direction, returning forward");
            return parentWeaponSystem.firePoint.TransformDirection(parentWeaponSystem.firePoint.right);
        }
    }

    public override void moveCrosshair(Vector2 moveDelta)
    {
        return;
    }
}
