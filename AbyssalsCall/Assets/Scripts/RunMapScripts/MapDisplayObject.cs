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

    //[SerializeField]
    //private Text depthText;

    MapDisplaySceneController SceneController;

    private int startDepth = 200;
    private int depthIncrement = 200;

    Animator MapPlainAinimtor;

    const float ScrollSensitivity = 0.005f;

    private void Update() {
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            MoveLayer(-1);
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            MoveLayer(1);
        }
    }

    public void UpdateMap(MapDisplaySceneController mdsc)
    {
        SceneController = mdsc;
        run.progress runProgress = RunManager.Instance.activeRun.IntToProgress(RunManager.Instance.activeRun.GetCurrentProgressInt() + 1);
        UpdateMap(runProgress.ZoneNum, runProgress.LayerNum);
    }

    public void UpdateMap(int zoneNum, int layerNum)
    {
        zone displayZone = RunManager.Instance.activeRun.GetZone(zoneNum);

        for(int printingLayerNum = 0; printingLayerNum < layerNum; printingLayerNum++ )
        {
            DisplayLayer(displayZone, printingLayerNum, layerNum, RunManager.Instance.activeRun.GetNodeChoiceFromProgress(new run.progress(zoneNum, printingLayerNum)));
        }
    }

    private void DisplayLayer(zone zone, int layerNum, int totalLayers, int nodeChoice)
    {
        //Transform layerPlain = Instantiate(MapPlainPrefab, new Vector3(0, -3 * layerNum, 0), Quaternion.identity).transform;

        Transform layerPlain = Instantiate(MapPlainPrefab, new Vector3(0, -3 * layerNum, 0), Quaternion.Euler(new Vector3(90,45,0))).transform;
        layerPlain.SetParent(transform);

        // depth text
        MapPlain mp = layerPlain.GetComponent<MapPlain>();
        mp.updateText(startDepth.ToString());
        startDepth += depthIncrement;

        // run the radar animation if it's the current layer
        MapPlainAinimtor = layerPlain.GetComponent<Animator>();
        if (layerNum == totalLayers-1)
        {
            MapPlainAinimtor.SetBool("currentLayer", true);
        }

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
                NodeChoiceInfo nci = SceneController.AddNewChoiceNodeInfoUI(NewNode);
                NewNode.OnHoverEnter += nci.HoverEnter;
                NewNode.OnHoverExit += nci.HoverExit;
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

    public void Scroll(float value)
    {
        transform.Translate(0, -value * ScrollSensitivity, 0);
    }

    public void MoveLayer(int deltaLayer)
    {
        transform.Translate(0,deltaLayer * 3,0);
    }

}
