using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventSceneController : SceneController
{
    public TMP_Text TitleTextBox;
    public TMP_Text DescriptionTextBox;

    public RectTransform LayoutTop;
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

        foreach(EventSO.Choice outcomeChoice in eventSO.Choices)
        {
            AddOutcomeButton(outcomeChoice);
        }

        UnityEngine.UI.ContentSizeFitter csf = ChoiceButtonContainer.GetComponent<UnityEngine.UI.ContentSizeFitter>();
        LayoutRebuilder.ForceRebuildLayoutImmediate(LayoutTop);
    }

    private void AddOutcomeButton(EventSO.Choice outcomeBase)
    {
        OutcomeButton ocb = Instantiate<OutcomeButton>(ChoiceButtonPrefab, Vector3.zero, Quaternion.identity, ChoiceButtonContainer);
        ocb.SetButtonText(outcomeBase.ChoiceText);
        bool suppressReturnToMap = false;
        foreach(ChoiceOutcome.OutcomeBase outcome in outcomeBase.ChoiceOutcomes)
        {
            suppressReturnToMap = suppressReturnToMap || outcome.SuppressReturnToMap;
            ocb.OnButtonClicked += outcome.ApplyOutcome;
        }
        if(!suppressReturnToMap)
        {
            ocb.OnButtonClicked += ()=>{GameObject.FindObjectOfType<SceneController>().ReturnToMapDisplay();} ;
        }
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
