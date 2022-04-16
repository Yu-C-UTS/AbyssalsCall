using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralWeaponSystem : WeaponSystemBase
{
    public delegate void UpdateNotify();
    public event UpdateNotify onWeaponUpdate;

    [SerializeField]
    private WeaponObject weaponObject;
    [SerializeField]
    protected WeaponAimBehaviorBase aimBehavior;
    [SerializeField]
    protected WeaponTriggerBehaviorBase triggerBehavior;
    [SerializeField]
    protected WeaponFireBehaviorBase fireBehavior;

    public Transform systemTransform{ get; protected set;}
    public Transform weaponTransform{ get; protected set;}
    public Transform firePoint{ get; protected set;}

    public override void InitilizeSystem(PlayerSubmarine parentSubmarine)
    {
        base.InitilizeSystem(parentSubmarine);

        Transform systemTransform = new GameObject(SystemName).transform;
        systemTransform.SetPositionAndRotation(registeredSubmarine.turretPivot.position, Quaternion.identity);
        systemTransform.SetParent(registeredSubmarine.transform);
        
        weaponObject.transform.SetPositionAndRotation(registeredSubmarine.turretPivot.position, Quaternion.identity);
        firePoint = weaponObject.FirePoint;
        weaponTransform = weaponObject.transform;
        weaponTransform.SetParent(registeredSubmarine.turretPivot);

        aimBehavior.InitilizeBehavior(systemTransform, this);
        triggerBehavior.InitilizeBehavior(systemTransform, this);        
        fireBehavior.InitilizeBehavior(systemTransform, this);
    }

    public override void TriggerBehavior(float triggerValue)
    {
        triggerBehavior.triggerBehavior(triggerValue);
    }

    public void Fire()
    {
        fireBehavior.Fire(firePoint, aimBehavior.GetFireDirection());
    }

    public virtual void WeaponUpdate()
    {
        onWeaponUpdate?.Invoke();
    }

    public override void RegisterSystem()
    {
        base.RegisterSystem();

        registeredSubmarine.onMouseMove += aimBehavior.moveCrosshair;
        registeredSubmarine.onSubUpdate += WeaponUpdate;
    }

    public override void UnRegisterSystem()
    {
        base.UnRegisterSystem();

        registeredSubmarine.onMouseMove -= aimBehavior.moveCrosshair;
        registeredSubmarine.onSubUpdate -= WeaponUpdate;
    }
}
