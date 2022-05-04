using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour, IDamagable
{
    public float Health = 100f;

    public void TakeDamage(Damage damage)
    {
        Health -= damage.baseDamageValue;
    }
}
