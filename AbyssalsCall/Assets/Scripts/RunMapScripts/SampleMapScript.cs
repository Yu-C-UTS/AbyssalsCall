using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMapScript : MonoBehaviour
{
    [SerializeField]
    MapNodeObj MapNodePrefab;
    [SerializeField]
    GameObject MapPlainPrefab;

    private void Start() 
    {
        for (int layer = 0; layer < 4; layer++)
        {
            Transform layerPlain = Instantiate(MapPlainPrefab, new Vector3(0, -3 * layer, 0), Quaternion.identity).transform;
            layerPlain.SetParent(transform);
            for (int i = 0; i < 4; i++)
            {
                MapNodeData newNodeData = new MapNodeData(new Vector3(Random.Range(-3f, 3f), (-3 * layer) + Random.Range(-0.2f, 0.2f), Random.Range(-3f, 3f)), (MapNodeData.ENodeType)Random.Range(0,4));
                MapNodeObj NewNode = Instantiate<MapNodeObj>(MapNodePrefab);
                NewNode.transform.SetParent(layerPlain);
                NewNode.nodeData = newNodeData;
            }            
        }
    }
}
