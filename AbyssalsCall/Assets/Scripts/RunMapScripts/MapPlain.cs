using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapPlain : MonoBehaviour
{
 
    [SerializeField] TextMeshProUGUI depthText;

    public void updateText(string depth)
    {
        depthText.text = depth+"m";
    }

}
