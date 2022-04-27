using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUniqueNodeData", menuName = "ScriptableObjects/MapGenData/NodeData/UniqueNode")]
public class UniqueNodeData : NodeDataBase
{
    public ENodeType nodeType = ENodeType.Origin;
    public string SceneName = "CombatScene";

    public override ENodeType NodeType
    {
        get
        {
            return nodeType;
        }
    }

    public override string LoadSceneName
    {
        get
        {
            return SceneName;
        }
    }
}
