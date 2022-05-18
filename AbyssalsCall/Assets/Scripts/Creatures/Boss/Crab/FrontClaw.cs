using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontClaw : MonoBehaviour
{
    [SerializeField]
    protected CrabBossState myState;
    protected Damage lightDamage = new Damage(8);
    protected Damage heavyDamage = new Damage(15);

    protected bool PlayerInRange = false;
    protected GameObject player;
    protected bool attacked = false;

    [SerializeField]
    protected AudioSource light;
    [SerializeField]
    protected AudioSource heavy;


    protected virtual void Update()
    {
        if (PlayerInRange && !attacked)
        {
            if (myState.state == CrabBossState.State.LightAttackFront)
            {
                player.GetComponent<PlayerSubmarine>().TakeDamage(lightDamage);
                Debug.Log("Light Attacked!");
                attacked = true;
                light.Play();
            }
            else if (myState.state == CrabBossState.State.HeavyAttack)
            {
                player.GetComponent<PlayerSubmarine>().TakeDamage(heavyDamage);
                Debug.Log("Heavey Attacked!");
                attacked = true;
                heavy.Play();
            }
        }
        else if (!PlayerInRange || myState.state == CrabBossState.State.Active)
        {
            attacked = false;
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
            player = collision.gameObject;
        }
    }


    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
            player = null;
        }
    }
}
