using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewTurretAimBehavior", menuName = "ScriptableObjects/WeaponBehavior/AimBehavior/TurretAimBehavior")]
public class TurretAimBehavior : WeaponAimBehaviorBase
{
    public override void AimUpdate()
    {
        Vector3 difference = crosshairTransform.position - parentWeaponSystem.weaponTransform.position;
        float rotationZ = Mathf.Atan2(difference.y,  parentWeaponSystem.weaponTransform.lossyScale.x * difference.x) * Mathf.Rad2Deg;
        rotationZ *= parentWeaponSystem.weaponTransform.lossyScale.x;
        parentWeaponSystem.weaponTransform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
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
