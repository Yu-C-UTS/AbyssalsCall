using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventSceneController : SceneController
{
    public TMP_Text TitleTextBox;
    public TMP_Text DescriptionTextBox;

    public Transform ChoiceButtonContainer;
    public OutcomeButton ChoiceButtonPrefab;

    EventNodeData activeEventNodeData;

    public override void SetupScene()
    {
        activeEventNodeData = RunManager.Instance.activeRun.GetLatestActiveNode().nodeDetailData as EventNodeData;

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

        foreach(EventSO.OutcomeBase outcomeChoice in eventSO.OutcomeChoices)
        {
            AddOutcomeButton(outcomeChoice);
        }
    }

    private void AddOutcomeButton(EventSO.OutcomeBase outcomeBase)
    {
        OutcomeButton ocb = Instantiate<OutcomeButton>(ChoiceButtonPrefab, Vector3.zero, Quaternion.identity, ChoiceButtonContainer);
        ocb.SetButtonText(outcomeBase.ButtonText);
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
