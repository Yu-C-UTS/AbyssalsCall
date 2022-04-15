using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGeneralWeaponSystem", menuName = "ScriptableObjects/SubmarineSystems/WeaponSystem/GeneralWeaponSystem")]
public class GeneralWeaponSystem : WeaponSystemBase
{
    public delegate void UpdateNotify();
    public event UpdateNotify onWeaponUpdate;

    [SerializeField]
    private WeaponObject weaponObjectPrefab;
    [SerializeField]
    private WeaponAimBehaviorBase aimBehavior;
    protected WeaponAimBehaviorBase aimBehaviorInstance;
    [SerializeField]
    private WeaponTriggerBehaviorBase triggerBehavior;
    protected WeaponTriggerBehaviorBase triggerBehaviorInstance;    
    [SerializeField]
    private WeaponFireBehaviorBase fireBehavior;
    protected WeaponFireBehaviorBase fireBehaviorInstance;

    public Transform systemTransform{ get; protected set;}
    public Transform weaponTransform{ get; protected set;}
    public Transform firePoint{ get; protected set;}

    public override void InitilizeSystem(PlayerSubmarine parentSubmarine)
    {
        base.InitilizeSystem(parentSubmarine);

        Transform systemTransform = new GameObject(SystemName).transform;
        systemTransform.SetPositionAndRotation(registeredSubmarine.turretPivot.position, Quaternion.identity);
        systemTransform.SetParent(registeredSubmarine.transform);
        WeaponObject instantiatedWeapon = Instantiate(weaponObjectPrefab, registeredSubmarine.turretPivot.position, Quaternion.identity);
        firePoint = instantiatedWeapon.FirePoint;
        weaponTransform = instantiatedWeapon.transform;
        weaponTransform.SetParent(registeredSubmarine.turretPivot);

        aimBehaviorInstance = Instantiate(aimBehavior);
        aimBehaviorInstance.InitilizeBehavior(systemTransform, this);
        triggerBehaviorInstance = Instantiate(triggerBehavior);
        triggerBehaviorInstance.InitilizeBehavior(systemTransform, this);        
        fireBehaviorInstance = Instantiate(fireBehavior);
        fireBehaviorInstance.InitilizeBehavior(systemTransform, this);
    }

    public override void TriggerBehavior(float triggerValue)
    {
        triggerBehaviorInstance.triggerBehavior(triggerValue);
    }

    public void Fire()
    {
        fireBehaviorInstance.Fire(firePoint, aimBehaviorInstance.GetFireDirection());
    }

    public virtual void WeaponUpdate()
    {
        onWeaponUpdate?.Invoke();
    }

    public override void RegisterSystem()
    {
        base.RegisterSystem();

        registeredSubmarine.onMouseMove += aimBehaviorInstance.moveCrosshair;
        registeredSubmarine.onSubUpdate += WeaponUpdate;
    }

    public override void UnRegisterSystem()
    {
        base.UnRegisterSystem();

        registeredSubmarine.onMouseMove -= aimBehaviorInstance.moveCrosshair;
        registeredSubmarine.onSubUpdate -= WeaponUpdate;
    }
}
