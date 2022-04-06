using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MapNodeObj : MonoBehaviour
{
    private MapNodeData _nodeData;
    public MapNodeData nodeData
    {
        get
        {
            return _nodeData;
        }
        
        set
        {
            _nodeData = value;
            transform.position = transform.TransformPoint(_nodeData.NodePosition/transform.lossyScale.x);
            GetComponent<Renderer>().material.SetColor("_NodeColor", nodeData.GetColor());
        }
    }

    private void OnMouseOver() 
    {
        //Debug.Log("Over Node");
    }

    private void OnMouseUp() 
    {
        Debug.Log("Node Click"); 
    }
}
