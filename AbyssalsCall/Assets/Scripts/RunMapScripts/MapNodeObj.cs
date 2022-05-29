using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Renderer))]
public class MapNodeObj : MonoBehaviour
{
    public bool Selectable = false;

    public node nodeInfo{ get; private set;}

    public delegate void ZeroParaDele();
    public event ZeroParaDele OnHoverEnter;
    public event ZeroParaDele OnHoverExit;

    [SerializeField]
    GameObject EventIcon;

    [SerializeField]
    GameObject EnemyIcon;

    [SerializeField]
    GameObject BossIcon;

    [SerializeField]
    GameObject ObjectiveCanvas;

    [SerializeField]
    TextMeshProUGUI ObjectiveText;

    [SerializeField]
    Button StartButton;

    private GameObject myIcon;
    private Animator iconAnimator;

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

        EventIcon.SetActive(false);
        EnemyIcon.SetActive(false);
        BossIcon.SetActive(false);

        ObjectiveCanvas.SetActive(false);

        rend.material.SetColor("_NodeColor", NodeObjColor(nodeInfo.nodeDetailData.NodeType));

        // set the icon
        switch (nodeInfo.nodeDetailData.NodeType)
        {
            case NodeDataBase.ENodeType.Enemy:
                EnemyIcon.SetActive(true);
                ObjectiveText.text = "Objective: Clear the area of all hostiles";
                myIcon = EnemyIcon;
            break;
            case NodeDataBase.ENodeType.Event:
                EventIcon.SetActive(true);
                ObjectiveText.text = "Entity unknown. Click to Investigate";
                myIcon = EventIcon;
            break;
            case NodeDataBase.ENodeType.Boss:
                BossIcon.SetActive(true);
                ObjectiveText.text = "Enormous abyssal crystal's detected. Proceed with caution";
                myIcon = BossIcon;
            break;
        }
       iconAnimator = myIcon.GetComponent<Animator>();
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
            //visited
            Debug.Log("visited");
            iconAnimator.SetBool("visited",true);
            break;

            case GlowState.dim:
            rend.material.SetFloat("_DoBlink", 0);
            rend.material.SetFloat("_IsBright", 0);
            //visited
            Debug.Log("visited");
            iconAnimator.SetBool("visited",true);
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
        ObjectiveCanvas.SetActive(true);
    }

    private void OnMouseExit()
    {
        OnHoverExit?.Invoke();
        ObjectiveCanvas.SetActive(false);
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
