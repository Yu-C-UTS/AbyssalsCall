using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : ProjectileBase
{
    public Vector2 HomingDelayMinMax = new Vector2(0.5f, 1f);
    public float HomingRandomRadius = 0.1f;
    public float HomingRotationRate = 5;

    private float projectileInstTime;

    private float homingDelay;
    private Vector3 homingTarget;
    private bool isHoming = false;

    public override void InitiateProjectile(WeaponSystemBase projectileWeaponSource)
    {
        base.InitiateProjectile(projectileWeaponSource);

        projectileInstTime = Time.time;
        homingDelay = Random.Range(Mathf.Min(HomingDelayMinMax.x, HomingDelayMinMax.y), Mathf.Max(HomingDelayMinMax.x, HomingDelayMinMax.y));
        homingTarget = projectileWeaponSource.GetTargetLocation() + (Vector3)(Random.insideUnitCircle * HomingRandomRadius);
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
        Vector3 r = Vector3.RotateTowards(rb2d.velocity.normalized, (Vector3)(homingTarget - transform.position).normalized, HomingRotationRate * Time.deltaTime, 0);
        rb2d.velocity = rb2d.velocity.magnitude * r;
    }
}
