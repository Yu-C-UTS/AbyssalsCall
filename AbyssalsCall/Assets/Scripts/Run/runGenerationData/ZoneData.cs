using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

[CreateAssetMenu(fileName = "NewZoneData", menuName = "ScriptableObjects/MapGenData/ZoneData")]
public class ZoneData : ScriptableObject
{
    [System.Serializable]
    public class LayerDetailDictionary : SerializableDictionaryBase<int, NodeDataSet<NodeDataBase>> {}
    [System.Serializable]
    public class NodeDataSet<T> where T : NodeDataBase
    {
        public T[] nodeData;

        public T GetRandomNode(int seed)
        {
            Random.InitState(seed);
            return nodeData[Random.Range(0, nodeData.Length - 1)];
        }
    }


    public string ZoneName;
    public int ZoneLayerCount = 15;
    public int MinRandomLayerNodeCount = 2;
    public int MaxRandomLayerNodeCount = 4;
    [Space(20)]
    public float CombatNodeWeight = 0.5f;
    public NodeDataSet<CombatNodeData> AvalibleCombatNodesForZone;
    [Space(20)]
    public float EventNodeWeight = 0.25f;
    public NodeDataSet<EventNodeData> AvalibleEventNodesForZone;
    [Space(20)]
    
    public LayerDetailDictionary PredefinedLayers;
}
