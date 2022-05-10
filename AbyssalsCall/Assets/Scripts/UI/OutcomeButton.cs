using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutcomeButton : MonoBehaviour
{
    public delegate void ButtonClickEvent();

    [SerializeField]
    private TMP_Text ButtonText;

    public event ButtonClickEvent OnButtonClicked;

    public void SetButtonText(string textToSet)
    {
        ButtonText.text = textToSet;
    }

    public void OnClicked()
    {
        OnButtonClicked?.Invoke();
    }
}
