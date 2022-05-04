using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutcomeButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ButtonText;

    public void SetButtonText(string textToSet)
    {
        ButtonText.text = textToSet;
    }

    public void OnClicked()
    {
        GameObject.FindObjectOfType<SceneController>().ReturnToMapDisplay();
    }
}
