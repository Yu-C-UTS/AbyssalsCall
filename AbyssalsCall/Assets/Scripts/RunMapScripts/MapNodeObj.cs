using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MapNodeObj : MonoBehaviour
{
    public bool Selectable = false;

    public node nodeInfo{ get; private set;}

    public delegate void ZeroParaDele();
    public event ZeroParaDele OnHoverEnter;
    public event ZeroParaDele OnHoverExit;

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

            case NodeDataBase.ENodeType.Maintenance:
            return Color.cyan;

            case NodeDataBase.ENodeType.Boss:
            return Color.black;

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

    private void OnMouseEnter() 
    {
        OnHoverEnter?.Invoke();
    }

    private void OnMouseExit()
    {
        OnHoverExit?.Invoke();
    }

    private void OnMouseUp() 
    {
        TriggerSelection();
    }

    public void TriggerSelection()
    {
        if(!Selectable)
        {
            return;
        }

        RunManager.Instance.StepRun(nodeInfo.nodeNum);
        GameSceneManager.Instance.LoadScene(nodeInfo.nodeDetailData.LoadSceneName);    
    }
}
