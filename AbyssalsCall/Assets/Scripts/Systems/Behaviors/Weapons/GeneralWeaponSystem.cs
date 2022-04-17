using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewGeneralWeaponSystem", menuName = "ScriptableObjects/SubmarineSystems/WeaponSystem/GeneralWeaponSystem")]
[RequireComponent(typeof(WeaponObject))]
public class GeneralWeaponSystem : WeaponSystemBase
{
    public delegate void UpdateNotify();
    public event UpdateNotify onWeaponUpdate;

    [SerializeField]
    private WeaponObject weaponObject;
    protected WeaponAimBehaviorBase aimBehavior;
    protected WeaponTriggerBehaviorBase triggerBehavior;    
    protected WeaponFireBehaviorBase fireBehavior;

    public Transform systemTransform{ get; protected set;}
    public Transform weaponTransform{ get; protected set;}
    public Transform firePoint{ get; protected set;}

    public override void InitilizeSystem(PlayerSubmarine parentSubmarine)
    {
        base.InitilizeSystem(parentSubmarine);

        Transform weaponAnchorPoint = registeredSubmarine.GetWeaponAnchorPoint(weaponObject.PreferedAnchorPoint);

        Transform systemTransform = new GameObject(SystemName).transform;
        systemTransform.SetPositionAndRotation(weaponAnchorPoint.position, Quaternion.identity);
        systemTransform.SetParent(registeredSubmarine.transform);

        weaponObject.transform.SetPositionAndRotation(weaponAnchorPoint.position, Quaternion.identity);
        firePoint = weaponObject.FirePoint;
        weaponTransform = weaponObject.transform;
        weaponTransform.SetParent(weaponAnchorPoint);

        aimBehavior = GetComponent<WeaponAimBehaviorBase>();
        aimBehavior.InitilizeBehavior(systemTransform, this);
        triggerBehavior = GetComponent<WeaponTriggerBehaviorBase>();
        triggerBehavior.InitilizeBehavior(systemTransform, this);   
        fireBehavior = GetComponent<WeaponFireBehaviorBase>();     
        fireBehavior.InitilizeBehavior(systemTransform, this);
    }

    public override void TriggerBehavior(float triggerValue)
    {
        triggerBehavior.triggerBehavior(triggerValue);
    }

    public void Fire()
    {
        fireBehavior.Fire();
    }

    public virtual void WeaponUpdate()
    {
        aimBehavior.AimUpdate();
        onWeaponUpdate?.Invoke();
    }

    public override Vector3 GetTargetLocation()
    {
        return aimBehavior.GetTargetPosition();
    }

    public override Vector3 GetAimDirection()
    {
        return aimBehavior.GetAimDirection();
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
