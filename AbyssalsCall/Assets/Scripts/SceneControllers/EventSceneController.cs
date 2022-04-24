using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSceneController : SceneController
{
    public Text TitleTextBox;
    public Text DescriptionTextBox;

    EventNodeData activeEventNodeData;

    public override void SetupScene()
    {
        activeEventNodeData = RunManager.Instance.GetLatestActiveNode().nodeDetailData as EventNodeData;

        if(activeEventNodeData == null)
        {
            Debug.LogError("Active node is not a recognised event node.");
        }

        UpdateEventText(activeEventNodeData.eventSo);
    }

    private void UpdateEventText(EventSO eventSO)
    {
        TitleTextBox.text = eventSO.EventName;
        DescriptionTextBox.text = eventSO.EveentDescription;
    }

    protected void OnValidate() 
    {
        if(TitleTextBox == null)
        {
            Debug.LogError("Title text box not assigned.");
        }

        if(DescriptionTextBox == null)
        {
            Debug.LogError("Description text box not assigned.");
        }
    }
}
