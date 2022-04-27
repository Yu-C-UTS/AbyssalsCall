using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapDisplayObject : MonoBehaviour
{
    [SerializeField]
    MapNodeObj MapNodePrefab;
    [SerializeField]
    GameObject MapPlainPrefab;

    const float ScrollSensitivity = 0.005f;

    public void UpdateMap()
    {
        run.progress runProgress = RunManager.Instance.activeRun.IntToProgress(RunManager.Instance.activeRun.GetCurrentProgressInt() + 1);
        UpdateMap(runProgress.ZoneNum, runProgress.LayerNum);
    }

    public void UpdateMap(int zoneNum, int layerNum)
    {
        zone displayZone = RunManager.Instance.activeRun.GetZone(zoneNum);

        for(int printingLayerNum = 0; printingLayerNum < layerNum; printingLayerNum++ )
        {
            DisplayLayer(displayZone, printingLayerNum, RunManager.Instance.activeRun.GetNodeChoiceFromProgress(new run.progress(zoneNum, printingLayerNum)));
        }
    }

    private void DisplayLayer(zone zone, int layerNum, int nodeChoice)
    {
        Transform layerPlain = Instantiate(MapPlainPrefab, new Vector3(0, -3 * layerNum, 0), Quaternion.identity).transform;
        layerPlain.SetParent(transform);

        layer displayLayer = zone.GetLayer(layerNum);
        for(int nodeNum = 0; nodeNum < displayLayer.nodeCount; nodeNum++)
        {
            MapNodeObj NewNode = Instantiate<MapNodeObj>(MapNodePrefab);
            NewNode.SetNodeInfo(displayLayer.GetNode(nodeNum));
            NewNode.transform.SetParent(layerPlain);
            Vector2 nodePos = displayLayer.GetNodePos(nodeNum);
            NewNode.transform.SetPositionAndRotation(new Vector3( nodePos.x, (-3 * layerNum) + Random.Range(-0.2f, 0.2f), nodePos.y), Quaternion.identity);
            
            if(nodeChoice == -1)
            {
                NewNode.SetNodeGlowState(MapNodeObj.GlowState.blink);
                NewNode.Selectable = true;
            }
            else if(nodeChoice == nodeNum)
            {
                NewNode.SetNodeGlowState(MapNodeObj.GlowState.bright);
            }
            else
            {
                NewNode.SetNodeGlowState(MapNodeObj.GlowState.dim);
            }
        }
    }

    public void OnScroll(InputAction.CallbackContext value)
    {
        transform.Translate(0, -value.ReadValue<float>() * ScrollSensitivity, 0);
    }

}
