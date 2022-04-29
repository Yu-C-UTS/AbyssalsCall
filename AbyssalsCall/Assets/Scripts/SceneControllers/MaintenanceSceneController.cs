using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintenanceSceneController : SceneController
{
    [SerializeField]
    RectTransform SystemListUIContainer;
    [SerializeField]
    SystemItemUI SystemItemUIPrefab;

    [Space(20)]

    [SerializeField]
    RectTransform SystemUpgradeListUIContainer;
    [SerializeField]
    GameObject SystemUpgradeItemUIPrefab;

    [Space(20)]

    [SerializeField]
    RectTransform UpgradeChoiceUIContainer;
    [SerializeField]
    GameObject UpgradeChoiceUIPrefab;

    [Space(20)]

    [SerializeField]
    RectTransform SystemStatUIContainer;
    [SerializeField]
    GameObject SystemStartUIPrefab;

    public override void SetupScene()
    {
        SubmarineStateData playerSSD = RunManager.Instance.ActivePlayerSubmarineStateData;
        foreach (KeyValuePair<string, SystemStateData> systemItem in playerSSD.SystemStatesDict)
        {
            SystemItemUI newSystemUIElement = Instantiate<SystemItemUI>(SystemItemUIPrefab, Vector3.zero, Quaternion.identity, SystemListUIContainer);
            newSystemUIElement.InitilizeUI(systemItem.Key, systemItem.Value);
        }
    }
}
