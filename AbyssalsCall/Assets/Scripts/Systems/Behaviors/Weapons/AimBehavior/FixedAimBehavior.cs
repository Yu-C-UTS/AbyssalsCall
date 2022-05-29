using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewFixedAimBehavior", menuName = "ScriptableObjects/WeaponBehavior/AimBehavior/FixedAimBehavior")]
public class FixedAimBehavior : WeaponAimBehaviorBase
{
    public float AimReticleRange = 5f;
    public Directions.EDirection WeaponAimDirection = Directions.EDirection.forward;
    [SerializeField]
    private LayerMask blockCrosshairLayerMask;

    public override void AimUpdate()
    {
        RaycastHit2D cast = Physics2D.CircleCast(parentWeaponSystem.firePoint.position, 0.5f, GetAimDirection(), AimReticleRange, blockCrosshairLayerMask);
        if(cast.transform != null)
        {
            crosshairTransform.SetPositionAndRotation(cast.point, Quaternion.identity);
        }
        else
        {
            crosshairTransform.SetPositionAndRotation(parentWeaponSystem.firePoint.position + (Vector3)GetAimDirection() * AimReticleRange, Quaternion.identity);
        }
    }

    public override Vector2 GetAimDirection()
    {
        return Directions.RelativeDirectionToV3(WeaponAimDirection, parentWeaponSystem.firePoint);
    }

    public override void moveCrosshair(Vector2 moveDelta)
    {
        return;
    }
}
