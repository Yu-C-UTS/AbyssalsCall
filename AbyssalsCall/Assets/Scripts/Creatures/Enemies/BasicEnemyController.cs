using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : BasicEnemyMovement, IDamagable
{
    [SerializeField]
    protected float maxHealth = 40;
    protected float Health;

    protected override void Awake()
    {
        Health = maxHealth;
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
