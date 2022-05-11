using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackClaw : FrontClaw
{
    protected override void Update()
    {
        if (PlayerInRange && !attacked)
        {
            if (myState.state == CrabBossState.State.LightAttackBack)
            {
                player.GetComponent<PlayerSubmarine>().TakeDamage(lightDamage);
                Debug.Log("Light Attacked!");
                attacked = true;
            }
            else if (myState.state == CrabBossState.State.HeavyAttack)
            {
                player.GetComponent<PlayerSubmarine>().TakeDamage(heavyDamage);
                Debug.Log("Heavey Attacked!");
                attacked = true;
            }
        }
        else if (!PlayerInRange || myState.state == CrabBossState.State.Active)
        {
            attacked = false;
        }
    }
}
