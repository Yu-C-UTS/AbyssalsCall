using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCombatNodeData", menuName = "ScriptableObjects/MapGenData/NodeData/CombatNode")]
public class CombatNodeData : NodeDataBase
{
    public override ENodeType NodeType
    {
        get
        {
            return ENodeType.Enemy;
        }
    }
}
