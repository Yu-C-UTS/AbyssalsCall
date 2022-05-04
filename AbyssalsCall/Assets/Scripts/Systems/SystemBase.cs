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

    [SerializeReference]
    protected List<SystemUpgrade> AvailableUpgrades;

    public virtual void InitilizeSystem(PlayerSubmarine parentSubmarine)
    {
        if(parentSubmarine == null)
        {
            return;
        }
        registeredSubmarine = parentSubmarine;
        transform.SetParent(registeredSubmarine.systemContainerTransform);
    }

    public abstract void RegisterSystem();

    public abstract void UnRegisterSystem();

    public abstract List<string> GetStats();

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

    protected void OnValidate() 
    {
        for (int i = AvailableUpgrades.Count - 1; i >= 0 ; i--)
        {
            if(AvailableUpgrades[i] != null)
            {
                continue;
            }
            AvailableUpgrades[i] = new SystemUpgrade();
        }
    }
}
