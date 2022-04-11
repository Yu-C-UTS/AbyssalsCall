using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField]
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
       currentHealth = MaxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
}
