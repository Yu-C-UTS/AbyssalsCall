using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SystemItemUI : MonoBehaviour
{
    private string refSystemKey;
    private SystemStateData refSystemStateData;

    [SerializeField]
    private TMP_Text systemNameText;

    public void InitilizeUI(string SystemStringKey, SystemStateData RefSystemStateData)
    {
        refSystemKey = SystemStringKey;
        refSystemStateData = RefSystemStateData;
        systemNameText.text = StringSystemConverter.Instance.StringToSystem(SystemStringKey).SystemName;
    }

    public void OnClick()
    {
        MaintenanceSceneController msc = FindObjectOfType<MaintenanceSceneController>();
        if(msc == null)
        {
            return;
        }
        msc.DisplaySystemInfo(StringSystemConverter.Instance.StringToSystem(refSystemKey));
    }
}
