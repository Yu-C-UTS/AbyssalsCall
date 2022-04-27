using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer
{
    public layer(NodeDataBase[] layerNodeData, int layerSeed)
    {
        Random.State holdState = Random.state;
        
        Random.InitState(layerSeed);
        currentRandomState = Random.state;

        layerNodes = new node[layerNodeData.Length];
        nodePositions = new Vector2[layerNodeData.Length];

        for (int i = 0; i < nodeCount; i++)
        {
            layerNodes[i] = new node(layerNodeData[i], i);
            nodePositions[i] = GetRandomInsideCircle() * 5;
        }

        Random.state = holdState;
    }

    private node[] layerNodes;
    private Vector2[] nodePositions;
    public int nodeCount
    { 
        get
        {
            return layerNodes.Length;
        }
    }

    private Random.State currentRandomState;

    public node GetNode(int nodeNum)
    {
        return layerNodes[nodeNum];
    }
    
    public Vector2 GetNodePos(int nodeNum)
    {
        return nodePositions[nodeNum];
    }

    private float GetRandomValue()
    {
        Random.State holdState = Random.state;
        float returnValue;
        Random.state = currentRandomState;
        returnValue = Random.value;
        currentRandomState = Random.state;
        Random.state = holdState;
        return returnValue;
    }

    private Vector2 GetRandomInsideCircle()
    {
        Random.State holdState = Random.state;
        Vector2 returnValue;
        Random.state = currentRandomState;
        returnValue = Random.insideUnitCircle;
        currentRandomState = Random.state;
        Random.state = holdState;
        return returnValue;
    }
}
