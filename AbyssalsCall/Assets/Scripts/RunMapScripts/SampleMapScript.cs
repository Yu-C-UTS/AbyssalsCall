using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SampleMapScript : MonoBehaviour
{
    [SerializeField]
    MapNodeObj MapNodePrefab;
    [SerializeField]
    GameObject MapPlainPrefab;

    const float ScrollSensitivity = 0.005f;

    public string seed = "HelloWorld";

    private zone activeZone;

    private void Start() 
    {
        RunManager.Instance.NewRun(seed);

        activeZone = RunManager.Instance.activeRun.GetCurrentZone();

        for(int layerNum = 0; layerNum < activeZone.LayerCount; layerNum++ )
        {
            Transform layerPlain = Instantiate(MapPlainPrefab, new Vector3(0, -3 * layerNum, 0), Quaternion.identity).transform;
            layerPlain.SetParent(transform);
        
            layer curLay = activeZone.GetLayer(layerNum);
            for(int nodeNum = 0; nodeNum < curLay.nodeCount; nodeNum++)
            {
                MapNodeObj NewNode = Instantiate<MapNodeObj>(MapNodePrefab);
                NewNode.SetNodeInfo(curLay.GetNode(nodeNum));
                NewNode.transform.SetParent(layerPlain);
                NewNode.transform.SetPositionAndRotation(new Vector3(Random.Range(-3f, 3f), (-3 * layerNum) + Random.Range(-0.2f, 0.2f), Random.Range(-3f, 3f)), Quaternion.identity);
            }
        }

        // for (int layer = 0; layer < 4; layer++)
        // {
        //     Transform layerPlain = Instantiate(MapPlainPrefab, new Vector3(0, -3 * layer, 0), Quaternion.identity).transform;
        //     layerPlain.SetParent(transform);
        //     for (int i = 0; i < 4; i++)
        //     {
        //         MapNodeData newNodeData = new MapNodeData(new Vector3(Random.Range(-3f, 3f), (-3 * layer) + Random.Range(-0.2f, 0.2f), Random.Range(-3f, 3f)), (MapNodeData.ENodeType)Random.Range(0,4));
        //         MapNodeObj NewNode = Instantiate<MapNodeObj>(MapNodePrefab);
        //         NewNode.transform.SetParent(layerPlain);
        //         NewNode.nodeData = newNodeData;
        //     }            
        // }
    }

    public void OnScroll(InputAction.CallbackContext value)
    {
        transform.Translate(0, -value.ReadValue<float>() * ScrollSensitivity, 0);
    }
}
