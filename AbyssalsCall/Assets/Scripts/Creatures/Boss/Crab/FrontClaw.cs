using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontClaw : MonoBehaviour
{
    [SerializeField]
    protected CrabBossState myState;
    protected Damage lightDamage = new Damage(8);
    protected Damage heavyDamage = new Damage(15);


    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float counter = 1;

            if(counter >= 1)
            {
                Debug.Log("Player!");
                if (myState.state == CrabBossState.State.LightAttackFront)
                {
                    collision.GetComponent<PlayerSubmarine>().TakeDamage(lightDamage);
                    Debug.Log("Light Attacked!");
                }
                else if (myState.state == CrabBossState.State.HeavyAttack)
                {
                    collision.GetComponent<PlayerSubmarine>().TakeDamage(heavyDamage);
                    Debug.Log("Heavey Attacked!");
                }
                counter -= 1;
            }
        }
    }
}
