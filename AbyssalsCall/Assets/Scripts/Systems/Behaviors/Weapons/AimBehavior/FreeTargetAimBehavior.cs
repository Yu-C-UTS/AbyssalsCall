using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeTargetAimBehavior : WeaponAimBehaviorBase
{
    public override void AimUpdate()
    {
        return;
    }

    public override Vector2 GetAimDirection()
    {
        Vector2 aimDirection = crosshairTransform.position - parentWeaponSystem.firePoint.position;
        return aimDirection.normalized;
    }

    public override void moveCrosshair(Vector2 moveDelta)
    {
        crosshairTransform.position += (Vector3)moveDelta;
    }

    public override void InitilizeBehavior(Transform WeaponTransform, GeneralWeaponSystem parentWeaponSystem)
    {
        base.InitilizeBehavior(WeaponTransform, parentWeaponSystem);

        //parentWeaponSystem.onWeaponUpdate += AimUpdate;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
