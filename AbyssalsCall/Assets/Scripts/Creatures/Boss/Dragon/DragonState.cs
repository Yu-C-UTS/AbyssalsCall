using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonState : MonoBehaviour, IDamagable
{
    [SerializeField]
    public float maxHealth = 550;
    public float Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

    public float getHealth()
    {
        return Health;
    }

    public void TakeDamage(Damage damage)
    {
        Health -= damage.baseDamageValue;
    }

}
