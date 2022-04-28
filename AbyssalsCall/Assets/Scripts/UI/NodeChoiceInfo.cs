using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeChoiceInfo : MonoBehaviour
{
    [SerializeField]
    TMP_Text InfoTopTxt;
    [SerializeField]
    TMP_Text InfoDeatilTxt;
    [SerializeField]
    Button button;

    MapNodeObj linkedNodeObject;

    public void InitializeInfo(MapNodeObj nodeObjectToLink)
    {
        linkedNodeObject = nodeObjectToLink;

        button.onClick.AddListener(linkedNodeObject.TriggerSelection);

        SetTitleText("POI:" + linkedNodeObject.nodeInfo.nodeNum.ToString());
        SetDetailText(linkedNodeObject.nodeInfo.nodeDetailData.GetNodeDetailText());
    }

    public void HoverEnter()
    {
        button.OnSelect(null);
    }
    
    public void HoverExit()
    {
        button.OnDeselect(null);
    }
    
    public void SetText(string TitleText, string ContentText)
    {
        SetTitleText(TitleText);
        SetDetailText(ContentText);
    }

    public void SetTitleText(string text)
    {
        InfoTopTxt.text = text;
    }

    public void SetDetailText(string text)
    {
        InfoDeatilTxt.text = text;
    }
}
