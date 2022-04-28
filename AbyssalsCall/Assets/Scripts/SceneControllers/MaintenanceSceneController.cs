using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintenanceSceneController : SceneController
{
    [SerializeField]
    RectTransform SystemListUIContainer;
    [SerializeField]
    GameObject SystemItemUIPrefab;

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
        throw new System.NotImplementedException();
    }
}
