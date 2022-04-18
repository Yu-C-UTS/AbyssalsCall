using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageProjectileFireBehavior : WeaponFireBehaviorBase
{
    [SerializeField]
    public ProjectileBase ProjectilePrefab;
    [SerializeField]
    public float ProjectileLaunchForce = 10f;
    [SerializeField]
    public int BarrageCount = 5;
    [SerializeField]
    public float FireInterval = 0.2f;
    [SerializeField]
    public float LaunchPointRandomRadius = 0.5f;

    public override void Fire()
    {
        StartCoroutine(FireCoroutine(BarrageCount, FireInterval, LaunchPointRandomRadius));
    }

    private IEnumerator FireCoroutine(int fireCount, float fireInterval, float launchRandomRadius)
    {
        int FiredCount = 0;
        float lastFireTime = 0;
        while(FiredCount < fireCount)
        {
            if(Time.time - lastFireTime >= fireInterval)
            {
                ProjectileBase fireProjectile = Instantiate(ProjectilePrefab, parentWeaponSystem.firePoint.position + (Vector3)Random.insideUnitCircle * launchRandomRadius, Quaternion.identity);
                fireProjectile.InitiateProjectile(parentWeaponSystem);
                //fireProjectile.rb2d.velocity = parentWeaponSystem.registeredSubmarine.rigidBody2d.velocity;
                fireProjectile.rb2d.AddForce(getFireDirectionVector() * ProjectileLaunchForce, ForceMode2D.Impulse);

                FiredCount += 1;
                lastFireTime = Time.time;
            }

            yield return null;
        }
    }
}
