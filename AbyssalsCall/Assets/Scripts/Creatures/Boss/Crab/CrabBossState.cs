using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBossState : MonoBehaviour, IDamagable
{
    
    [SerializeField]
    public float maxHealth = 200;
    public float Health;

    private Transform target;

    public enum State
    {
        Idle, Active, LightAttackFront, LightAttackBack, HeavyAttack, Blocking, Dead
    }
    public State state;

    private void Awake()
    {
        Health = maxHealth;
        state = State.Idle;
    }

    private void FixedUpdate()
    {
        if(target == null)
        {
            target = detectPlayer("Player", 50);
        }
    }

    public float getHealth()
    {
        return Health;
    }
    public void TakeDamage(Damage damage)
    {
        Health -= damage.baseDamageValue;
    }

    protected Transform detectPlayer(string targetTag, float detectR)
    {
        var hitColliders = Physics2D.OverlapCircleAll(transform.position, detectR);
        foreach (var collider in hitColliders)
        {
            if (collider.gameObject.CompareTag(targetTag))
            {
                Debug.Log("detected");
                state = State.Active;
                Debug.Log(collider.gameObject.transform);
                return collider.gameObject.transform.GetChild(0).transform;
            }
        }

        return null;
    }

    public Transform getTarget()
    {
        return target;
    }

}
