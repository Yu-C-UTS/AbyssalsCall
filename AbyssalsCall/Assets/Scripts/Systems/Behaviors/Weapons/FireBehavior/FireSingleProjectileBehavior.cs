using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewSingleProjectileFireBehavior", menuName = "ScriptableObjects/WeaponBehavior/FireBehavior/SingleProjectileFireBehavior")]
public class FireSingleProjectileBehavior : WeaponFireBehaviorBase
{
    [SerializeField]
    public ProjectileBase ProjectilePrefab;
    [SerializeField]
    public float ProjectileLaunchForce = 10f;

    public override void Fire()
    {
        ProjectileBase fireProjectile = Instantiate(ProjectilePrefab, parentWeaponSystem.firePoint.position, Quaternion.identity);
        fireProjectile.InitiateProjectile(parentWeaponSystem);
        //fireProjectile.rb2d.velocity = parentWeaponSystem.registeredSubmarine.rigidBody2d.velocity;
        fireProjectile.rb2d.AddForce(getFireDirectionVector() * ProjectileLaunchForce, ForceMode2D.Impulse);
    }

    public override string[] GetStats()
    {
        List<string> returnStatList = new List<string>();
        returnStatList.AddRange(ProjectilePrefab.GetProjectileStats());
        returnStatList.Add("Projectile Launch Force: "+ ProjectileLaunchForce);
        return returnStatList.ToArray();
    }
}
