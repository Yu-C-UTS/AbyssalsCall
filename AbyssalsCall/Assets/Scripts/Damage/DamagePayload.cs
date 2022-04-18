using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicDamagePayload", menuName = "ScriptableObjects/BasicDamagePayload", order = 1)]
public class DamagePayload : Payload
{
    public Damage PayloadDamage;

    public override void ActivatePayload(IDamagable targetDamagable, GameObject targetGameObject)
    {
        targetDamagable.TakeDamage(PayloadDamage);
    }
}
