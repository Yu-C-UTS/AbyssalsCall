using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewSingleTriggerBehavior", menuName = "ScriptableObjects/WeaponBehavior/TriggerBehavior/SingleTriggerBehavior")]
public class SingleTrigger : WeaponTriggerBehaviorBase
{
    public float TriggerCooldown = 2f;
    private float currentCooldown = 0f;

    private bool triggerRegistered = false;
    private bool isCoolingWeapon = false;

    public override void triggerBehavior(float triggerValue)
    {
        if(triggerValue >= triggerThreshold)
        {
            if(triggerRegistered) return;
            triggerRegistered = true;

            if(currentCooldown > 0) return;

            CallFire();
        }
        else
        {
            triggerRegistered = false;
        }
    }

    private void CallFire()
    {
        currentCooldown = TriggerCooldown;
        parentWeaponSystem.Fire();

        if(!isCoolingWeapon)
        {
            isCoolingWeapon = true;
            parentWeaponSystem.onWeaponUpdate += WeaponCoolUpdate;
        }
    }

    public void WeaponCoolUpdate()
    {
        currentCooldown -= Time.deltaTime;

        if(currentCooldown <= 0)
        {
            currentCooldown = 0;
            parentWeaponSystem.onWeaponUpdate -= WeaponCoolUpdate;
            isCoolingWeapon = false;
        }
    }
}
