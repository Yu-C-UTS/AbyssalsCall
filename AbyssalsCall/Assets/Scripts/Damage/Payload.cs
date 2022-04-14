using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Payload : ScriptableObject
{
    public abstract void ActivatePayload(IDamagable targetDamagable, GameObject targetGameObject);
}
