using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SystemBehaviorBase : MonoBehaviour
{
    protected PlayerSubmarine registeredSubmarine;

    public virtual void InitilizeSystem(PlayerSubmarine parentSubmarine)
    {
        registeredSubmarine = parentSubmarine;
        transform.SetParent(registeredSubmarine.systemContainerTransform);
    }

    public abstract void RegisterSystem();

    public abstract void UnRegisterSystem();

    protected virtual void OnEnable() 
    {
        if(registeredSubmarine)
        {
            RegisterSystem();
        }
    }

    protected virtual void OnDisable()
    {
        if(registeredSubmarine)
        {
            UnRegisterSystem();
        }
    }
}
