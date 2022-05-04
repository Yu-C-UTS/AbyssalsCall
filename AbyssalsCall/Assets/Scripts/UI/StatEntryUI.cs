using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatEntryUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text StatText;

    public void SetStatText(string statString)
    {
        StatText.text = statString;
    }
}
