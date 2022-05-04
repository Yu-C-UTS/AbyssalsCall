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
    StatEntryUI SystemStatUIPrefab;

    public override void SetupScene()
    {
        SubmarineStateData playerSSD = RunManager.Instance.ActivePlayerSubmarineStateData;
        foreach (KeyValuePair<string, SystemStateData> systemItem in playerSSD.SystemStatesDict)
        {
            SystemItemUI newSystemUIElement = Instantiate<SystemItemUI>(SystemItemUIPrefab, Vector3.zero, Quaternion.identity, SystemListUIContainer);
            newSystemUIElement.InitilizeUI(systemItem.Key, systemItem.Value);
        }
    }

    public void DisplaySystemInfo(SystemBase systemToDisplay)
    {
        SystemBase newSystem = Instantiate(systemToDisplay);
        newSystem.InitilizeSystem(null);
        for (int i = 0; i < SystemStatUIContainer.childCount; i++)
        {
            Destroy(SystemStatUIContainer.GetChild(i).gameObject);        
        }
        foreach(string statEntry in newSystem.GetStats())
        {
            StatEntryUI newStatEntryUIElement = Instantiate<StatEntryUI>(SystemStatUIPrefab, Vector3.zero, Quaternion.identity, SystemStatUIContainer);
            newStatEntryUIElement.SetStatText(statEntry);
        }
        Destroy(newSystem.gameObject);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
