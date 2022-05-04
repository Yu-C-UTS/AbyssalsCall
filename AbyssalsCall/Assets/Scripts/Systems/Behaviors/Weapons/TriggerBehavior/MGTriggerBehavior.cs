using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewMGTriggerBehavior", menuName = "ScriptableObjects/WeaponBehavior/TriggerBehavior/MGTriggerBehavior")]
public class MGTriggerBehavior : WeaponTriggerBehaviorBase
{
    [SerializeField]
    protected float weaponFireRate = 3;
    protected float weaponFireCountdown = 0;

    [SerializeField]
    protected float weaponMaxHeat = 100f;
    protected float weaponCurrentHeat = 0;
    [SerializeField]
    protected float weaponHeatPerShot = 12f;
    [SerializeField]
    protected float weaponCoolingRate = 10f;
    private bool isCoolingWeapon = false;
    private bool isFiring = false;

    public override void triggerBehavior(float triggerValue)
    {
        if(triggerValue >= triggerThreshold)
        {
            if(isFiring) return;
            isFiring = true;
            parentWeaponSystem.onWeaponUpdate += WeaponFireUpdate;
            if(!isCoolingWeapon)
            {
                isCoolingWeapon = true;
                parentWeaponSystem.onWeaponUpdate += WeaponCoolUpdate;
            }
        }
        else
        {
            if(!isFiring) return;
            parentWeaponSystem.onWeaponUpdate -= WeaponFireUpdate;
            isFiring = false;
        }
    }

    protected void WeaponFireUpdate()
    {
        if(weaponFireCountdown <= 0 && weaponMaxHeat - weaponCurrentHeat > weaponHeatPerShot)
        {
            WeaponFire();
        }
        weaponFireCountdown = Mathf.Max(weaponFireCountdown - Time.deltaTime, 0);
    }

    protected void WeaponFire()
    {
        weaponFireCountdown += 1/weaponFireRate;
        weaponCurrentHeat += weaponHeatPerShot;
        parentWeaponSystem.Fire();
    }

    protected void WeaponCoolUpdate()
    {
        weaponCurrentHeat -= weaponCoolingRate * Time.deltaTime;

        if(weaponCurrentHeat <= 0)
        {
            weaponCurrentHeat = 0;
            parentWeaponSystem.onWeaponUpdate -= WeaponCoolUpdate;
            isCoolingWeapon = false;
        }
    }

}
