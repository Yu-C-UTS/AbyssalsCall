using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEventNodeData", menuName = "ScriptableObjects/MapGenData/NodeData/EventNode")]
public class EventNodeData : NodeDataBase
{
    public override ENodeType NodeType
    {
        get
        {
            return ENodeType.Event;
        }
    }
}
