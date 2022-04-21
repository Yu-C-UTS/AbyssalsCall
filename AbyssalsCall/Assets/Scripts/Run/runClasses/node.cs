using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node
{
    public node(NodeDataBase nodeData)
    {
        nodeDetailData = nodeData;
    }

    public Vector2 position;
    public NodeDataBase nodeDetailData;
}
