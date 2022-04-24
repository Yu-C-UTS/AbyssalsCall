using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MapNodeObj : MonoBehaviour
{
    public bool Selectable = false;

    public node nodeInfo{ get; private set;}

    public enum GlowState
    { blink, bright, dim}

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

    public void SetNodeInfo(node nodeInfo)
    {
        this.nodeInfo = nodeInfo;
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor("_NodeColor", NodeObjColor(nodeInfo.nodeDetailData.NodeType));
    }

    public void SetNodeGlowState(GlowState glowState)
    {
        Renderer rend = GetComponent<Renderer>();
        switch(glowState)
        {
            case GlowState.blink:
            rend.material.SetFloat("_DoBlink", 1);
            break;

            case GlowState.bright:
            rend.material.SetFloat("_DoBlink", 0);
            rend.material.SetFloat("_IsBright", 1);
            break;

            case GlowState.dim:
            rend.material.SetFloat("_DoBlink", 0);
            rend.material.SetFloat("_IsBright", 0);
            break;

            default:
            Debug.LogError("Unknown State, Setting self to dim.");
            rend.material.SetFloat("_DoBlink", 0);
            rend.material.SetFloat("_IsBright", 0);
            break;
        }
    }

    private void OnMouseOver() 
    {
        //Debug.Log("Over Node");
    }

    private void OnMouseUp() 
    {
        if(!Selectable)
        {
            return;
        }

        RunManager.Instance.StepRun(nodeInfo.nodeNum);

        Debug.Log("Loading Scene: " + nodeInfo.nodeDetailData.LoadSceneName);
        GameSceneManager.Instance.LoadScene(nodeInfo.nodeDetailData.LoadSceneName);
    }
}
