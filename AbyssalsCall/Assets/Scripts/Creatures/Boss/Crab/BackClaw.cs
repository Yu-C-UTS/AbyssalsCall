using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackClaw : FrontClaw
{
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player!");
            if (myState.state == CrabBossState.State.LightAttackBack)
            {
                collision.GetComponent<PlayerSubmarine>().TakeDamage(lightDamage);
                Debug.Log("Light Attacked! Back");
            }
            else if (myState.state == CrabBossState.State.HeavyAttack)
            {
                collision.GetComponent<PlayerSubmarine>().TakeDamage(heavyDamage);
                Debug.Log("Heavey Attacked!");
            }
        }
    }
}
