using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSingleProjectileFireBehavior", menuName = "ScriptableObjects/WeaponBehavior/FireBehavior/SingleProjectileFireBehavior")]
public class FireSingleProjectileBehavior : WeaponFireBehaviorBase
{
    [SerializeField]
    public ProjectileBase ProjectilePrefab;
    [SerializeField]
    public float ProjectileLaunchForce = 10f;

    public override void Fire(Transform FirePoint, Vector2 FireDirection)
    {
        ProjectileBase fireProjectile = Instantiate(ProjectilePrefab, FirePoint.position, Quaternion.identity);
        fireProjectile.InitiateProjectile(parentWeaponSystem.registeredSubmarine.gameObject);
        //fireProjectile.rb2d.velocity = parentWeaponSystem.registeredSubmarine.rigidBody2d.velocity;
        fireProjectile.rb2d.AddForce(FireDirection * ProjectileLaunchForce, ForceMode2D.Impulse);
    }
}
