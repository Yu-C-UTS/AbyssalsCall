using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBossBehaviour : MonoBehaviour
{

    private Transform target;
    private Rigidbody2D rb;

    [SerializeField]
    private CrabBoss anim;

    [SerializeField]
    private Transform myCenter;

    private float AttackTime = 3;
    private float AttackTimer;
    private int AttackCount;


    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        AttackTimer = AttackTime;
    }

    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (target)
        {
            if(VerticalDistanceTo(target) >= 10)
            {
                //PullDown(target);
            }
        }

        if (distanceTo(target) <= 5)
        {
            if (AttackCountDown() == 0)
            {
                if (AttackCount != 0 && AttackCount % 3 == 1)
                {
                    heavyAttack();
                }
                else
                {
                    lightAttack();
                }
            }
        }
    }

    private float AttackCountDown()
    {
        if(AttackTimer <= 0)
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

    protected float distanceTo(Transform target)
    {
        return Vector2.Distance(target.position, transform.position);
    }

    protected float VerticalDistanceTo(Transform target)
    {
        return Mathf.Abs(target.position.y - transform.position.y);
    }

    private void PullDown(Transform target)
    {
        Rigidbody2D trb = target.gameObject.GetComponent<Rigidbody2D>();
        trb.AddForce(-directionTo(target)*2);
    }

    private Vector2 directionTo(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        return direction.normalized;
    }

    private void lightAttack()
    {
        anim.AddAnimation(anim.lightAttackFront,false);
    }

    private void heavyAttack()
    {
        anim.AddAnimation(anim.heavyAttack, false);
    }
}
