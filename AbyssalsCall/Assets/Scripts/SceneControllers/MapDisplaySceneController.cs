using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplaySceneController : SceneController
{
    [SerializeField]
    MapDisplayObject MapDisplayObjectPrefab;

    MapDisplayObject mapDisplay;

    [SerializeField]
    RectTransform NodeChoiceUIContainer;
    [SerializeField]
    NodeChoiceInfo NodeChoiceUIPrefab;

    public override void SetupScene()
    {
        mapDisplay = Instantiate(MapDisplayObjectPrefab, Vector3.zero, Quaternion.identity);
        mapDisplay.UpdateMap(this);
        mapDisplay.MoveLayer(RunManager.Instance.activeRun.GetCurrentLayerNum());
    }

    public NodeChoiceInfo AddNewChoiceNodeInfoUI(MapNodeObj NodeObj)
    {
        NodeChoiceInfo newChoiceInfoUI = Instantiate<NodeChoiceInfo>(NodeChoiceUIPrefab, Vector3.zero, Quaternion.identity, NodeChoiceUIContainer);
        newChoiceInfoUI.InitializeInfo(NodeObj);
        return newChoiceInfoUI;
    }
}
