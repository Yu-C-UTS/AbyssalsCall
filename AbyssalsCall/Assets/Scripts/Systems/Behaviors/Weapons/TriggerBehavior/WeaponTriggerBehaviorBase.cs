using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponTriggerBehaviorBase : WeaponBehaviorBase
{
    public override void InitilizeBehavior(Transform WeaponTransform, GeneralWeaponSystem parentWeaponSystem)
    {
        base.InitilizeBehavior(WeaponTransform, parentWeaponSystem);
        weaponCooldownHUDObj = Instantiate<WeaponCooldownHUD>(weaponCooldownHUDObjPrefab, Vector3.zero, Quaternion.identity, parentWeaponSystem.registeredSubmarine.WeaponHudParent);
        weaponCooldownHUDObj.SetWeaponSprite(parentWeaponSystem.SystemArtSprite);
    }

    protected const float triggerThreshold = 0.7f;

    public abstract void triggerBehavior(float triggerValue);

    [SerializeField]
    private WeaponCooldownHUD weaponCooldownHUDObjPrefab;
    protected WeaponCooldownHUD weaponCooldownHUDObj;
}
