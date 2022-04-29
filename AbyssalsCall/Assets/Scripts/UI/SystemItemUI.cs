using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SystemItemUI : MonoBehaviour
{
    private SystemStateData refSystemStateData;

    [SerializeField]
    private TMP_Text systemNameText;

    public void InitilizeUI(string SystemStringKey, SystemStateData RefSystemStateData)
    {
        refSystemStateData = RefSystemStateData;
        systemNameText.text = StringSystemConverter.Instance.StringToSystem(SystemStringKey).SystemName;
    }
}
