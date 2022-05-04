using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : BasicEnemyMovement, IDamagable
{
    public float Health = 40;

    protected override void Awake()
    {
        Health = 40;
        pfController = new PathfindingController(transform, PickRandomPoint());
    }

    protected void Update()
    {
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(Damage damage)
    {
        Health -= damage.baseDamageValue;
    }
}
