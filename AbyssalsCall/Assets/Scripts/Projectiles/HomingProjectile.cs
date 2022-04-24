using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : ProjectileBase
{
    public bool KeepTrackingTarget = false;
    [Header("Homing Start Delay")]
    public float HomingDelayMin = 0.5f;
    public float HomingDelayMax = 1f;
    [Space(20)]
    public float TargetInaccuracyRadius = 0.1f;
    public float HomingRotationRate = 5;

    private float projectileInstTime;

    private float homingDelay;
    private Transform homingTarget;
    private Vector3 homingPosition;
    private bool isHoming = false;

    public override void InitiateProjectile(WeaponSystemBase projectileWeaponSource)
    {
        base.InitiateProjectile(projectileWeaponSource);

        projectileInstTime = Time.time;
        homingDelay = Random.Range(HomingDelayMin, HomingDelayMax);
        homingTarget = projectileWeaponSource.GetTargetTransform();
        homingPosition = homingTarget.position + (Vector3)(Random.insideUnitCircle * TargetInaccuracyRadius);
    }

    protected void Update()
    {
        if(isHoming)
        {
            homingBehaviorUpdate();
            return;
        }

        if(Time.time - projectileInstTime > homingDelay)
        {
            isHoming = true;
            return;
        }
    }

    protected void homingBehaviorUpdate()
    {
        if(KeepTrackingTarget)
        {
            homingPosition = homingTarget.position + (Vector3)(Random.insideUnitCircle * TargetInaccuracyRadius);
        }

        Vector3 r = Vector3.RotateTowards(rb2d.velocity.normalized, (Vector3)(homingPosition - transform.position).normalized, HomingRotationRate * Time.deltaTime, 0);
        rb2d.velocity = rb2d.velocity.magnitude * r;
    }

    private void OnValidate() 
    {
        if(HomingDelayMin > HomingDelayMax)
        {
            Debug.LogWarning("Homing Delay Max is lower than Min on: " + name);
        }    
    }
}
