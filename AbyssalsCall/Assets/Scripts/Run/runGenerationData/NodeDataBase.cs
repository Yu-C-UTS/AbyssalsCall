using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeDataBase : ScriptableObject
{
    public enum ENodeType
    {Origin, Enemy, Event, Boss}

    public virtual ENodeType NodeType
    {
        get
        {
            return ENodeType.Origin;
        }
    }
}
