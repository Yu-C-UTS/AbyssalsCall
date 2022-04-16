using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SystemBase : MonoBehaviour
{
    public PlayerSubmarine registeredSubmarine{ get; protected set;}

    [field: SerializeField]
    public string SystemName { get; protected set;} = "New System";
    [SerializeField]
    private bool isUnique = false;

    [SerializeField]
    private bool isRemovable = true;

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
