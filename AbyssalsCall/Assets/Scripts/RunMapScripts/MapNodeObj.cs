using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MapNodeObj : MonoBehaviour
{
    private node _nodeInfo;
    public node nodeInfo
    {
        get
        {
            return _nodeInfo;
        }
        
        set
        {
            _nodeInfo = value;
            //transform.position = transform.TransformPoint(_nodeInfo.NodePosition/transform.lossyScale.x);
            GetComponent<Renderer>().material.SetColor("_NodeColor", NodeObjColor(nodeInfo.nodeDetailData.NodeType));
        }
    }

    private static Color NodeObjColor(NodeDataBase.ENodeType nodeType)
    {
        switch(nodeType)
        {
            case NodeDataBase.ENodeType.Origin:
            return Color.white;

            case NodeDataBase.ENodeType.Enemy:
            return Color.red;

            case NodeDataBase.ENodeType.Event:
            return Color.yellow;

            case NodeDataBase.ENodeType.Boss:
            return Color.gray;

            default:
            return Color.white;
        }

    }

    private void OnMouseOver() 
    {
        //Debug.Log("Over Node");
    }

    private void OnMouseUp() 
    {
        Debug.Log("Loading Game Scene");
        SceneManager.LoadScene("GameDemoScene");
    }
}
