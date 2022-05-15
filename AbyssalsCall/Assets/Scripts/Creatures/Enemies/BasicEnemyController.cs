using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : BasicEnemyMovement, IDamagable
{
    [SerializeField]
    protected float maxHealth = 40;
    protected float Health;

    public float AttackTime;
    protected float AttackTimer;
    protected bool canAttack;
    protected Damage basicDamage = new Damage(5);

    protected override void Awake()
    {
        Health = maxHealth;
        AttackTimer = AttackTime;
        canAttack = true;
        pfController = new PathfindingController(transform, PickRandomPoint());
    }

    protected void Update()
    {
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (!canAttack)
        {
            if(AttackCountDown() == 0)
            {
                canAttack = true;
            }
        }

    }
    public void TakeDamage(Damage damage)
    {
        Health -= damage.baseDamageValue;
    }

    protected virtual float AttackCountDown()
    {
        if (AttackTimer <= 0)
        {
            AttackTimer = AttackTime;
            return 0;
        }
        else
        {
            AttackTimer -= Time.deltaTime;
            return AttackTimer;
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (canAttack)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerSubmarine>().TakeDamage(basicDamage);
                canAttack = false;
            }
        }
    }
}
