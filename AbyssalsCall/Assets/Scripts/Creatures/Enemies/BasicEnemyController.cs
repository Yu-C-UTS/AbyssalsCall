using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasicEnemyController : BasicEnemyMovement, IDamagable
{
    [SerializeField]
    public float maxHealth = 40;
    public float Health;

    public float AttackTime;
    protected float AttackTimer;
    protected bool canAttack;
    protected Damage basicDamage = new Damage(5);

    public event EventHandler<OnDestroyedEventArgs> OnDestroyed;
    public class OnDestroyedEventArgs : EventArgs {
        // args here
        public Vector3 pos;
    }

    //public event DestroyedEventDelegate OnBoom;
    //public delegate void DestroyedEventDelegate(Vector3 pos);

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
            // show explosion
          
           OnDestroyed?.Invoke(this, new OnDestroyedEventArgs {pos = new Vector3(this.transform.position.x, this.transform.position.y, 0)});

           // OnBoom?.Invoke(this.transform.position);

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
