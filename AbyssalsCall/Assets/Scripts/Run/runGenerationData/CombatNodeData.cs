using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCombatNodeData", menuName = "ScriptableObjects/MapGenData/NodeData/CombatNode")]
public class CombatNodeData : NodeDataBase
{
    [SerializeField]
    private string SceneNameToLoad = "EnemyTestScene";

    public override ENodeType NodeType
    {
        get
        {
            return ENodeType.Enemy;
        }
    }

    public override string LoadSceneName
    {
        get
        {
            return SceneNameToLoad;
        }
    }

    public override string GetNodeDetailText()
    {       
        return "Enemy Detected";
    }
}
