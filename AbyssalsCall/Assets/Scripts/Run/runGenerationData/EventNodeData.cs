using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEventNodeData", menuName = "ScriptableObjects/MapGenData/NodeData/EventNode")]
public class EventNodeData : NodeDataBase
{
    public EventSO eventSo;

    public override ENodeType NodeType
    {
        get
        {
            return ENodeType.Event;
        }
    }

    public override string LoadSceneName
    {
        get
        {
            return "EventScene";
        }
    }

    public override string GetNodeDetailText()
    {
        return "Unknown Signal Detected";    
    }
}
