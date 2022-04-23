using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeDataBase : ScriptableObject
{
    public enum ENodeType
    {Origin, Enemy, Event, Boss}

    public abstract ENodeType NodeType
    {
        get;
    }

    public abstract string LoadSceneName
    {
        get;
    }
}
