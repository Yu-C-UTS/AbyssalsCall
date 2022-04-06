using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapNodeData
{
    public enum ENodeType
    {Origin, Enemy, Event, Boss}

    public MapNodeData()
    {
        NodePosition = Vector3.zero;
        NodeType = ENodeType.Origin;
    }

    public MapNodeData(Vector3 position, ENodeType type)
    {
        NodePosition = position;
        NodeType = type;
    }

    public Vector3 NodePosition;
    public ENodeType NodeType;

    public Color GetColor()
    {
        switch(NodeType)
        {
            case ENodeType.Origin:
            return Color.white;

            case ENodeType.Enemy:
            return Color.red;

            case ENodeType.Event:
            return Color.yellow;

            case ENodeType.Boss:
            return Color.gray;

            default:
            return Color.white;
        }
    }
}
