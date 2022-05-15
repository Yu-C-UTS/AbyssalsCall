using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMaintenanceNodeData", menuName = "ScriptableObjects/MapGenData/NodeData/Maintenance")]
public class MaintenanceNodeData : NodeDataBase
{
    public override ENodeType NodeType
    {
        get
        {
            return ENodeType.Maintenance;
        }
    }

    public override string LoadSceneName
    {
        get
        {
            return "MaintenanceScene";
        }
    }

    public override string GetNodeDetailText()
    {
        return "A fine place to perform some quick maintenance.";
    }
}
