using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node
{
    public node(NodeDataBase nodeData, int nodeNum)
    {
        this.nodeNum = nodeNum;
        nodeDetailData = nodeData;
    }

    public readonly int nodeNum;

    public Vector2 position;
    public NodeDataBase nodeDetailData;
}
