using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehaviour : MonoBehaviour
{
    public float AttackTime = 4;
    private float AttackTimer;
    private bool CanAttack;
    public Damage DragonDamage = new Damage(17);

    private void Start()
    {
        AttackTimer = AttackTime;
        CanAttack = false;
    }

    private void Update()
    {
        if(AttackCountDown() == 0)
        {
            CanAttack = true;
        }
    }

    private float AttackCountDown()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerSubmarine>().TakeDamage(DragonDamage);
            CanAttack = false;
        }
    }
}
