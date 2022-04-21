using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone
{
    public zone(ZoneData zoneData)
    {
        this.zoneData = zoneData;
    }

    public ZoneData zoneData{ get; private set;}
    private layer[] zoneLayers;
    public int LayerCount 
    {
        get
        {
            return zoneLayers.Length;        
        }
    }

    public void InitilizeZone(int seed)
    {
        Random.InitState(seed);

        zoneLayers = new layer[zoneData.ZoneLayerCount];
        for(int i = 0; i < zoneData.ZoneLayerCount; i++)
        {
            ZoneData.NodeDataSet<NodeDataBase> layerNodesDataSet;
            if(zoneData.PredefinedLayers.TryGetValue(i, out layerNodesDataSet))
            {
                zoneLayers[i] = new layer(layerNodesDataSet.nodeData, Random.Range(0, int.MaxValue));
                continue;
            }

            layerNodesDataSet = new ZoneData.NodeDataSet<NodeDataBase>();
            int layerNodeCount = Random.Range(zoneData.MinRandomLayerNodeCount ,zoneData.MaxRandomLayerNodeCount + 1);
            layerNodesDataSet.nodeData = new NodeDataBase[layerNodeCount];
            float totalRandWeight = zoneData.CombatNodeWeight + zoneData.EventNodeWeight;
            for (int j = 0; j < layerNodeCount; j++)
            {
                float layerRand = Random.Range(0, totalRandWeight);
                
                if(layerRand <= zoneData.CombatNodeWeight)
                {
                    layerNodesDataSet.nodeData[j] = zoneData.AvalibleCombatNodesForZone.GetRandomNode(Random.Range(0, int.MaxValue));
                    continue;
                }
                   
                layerNodesDataSet.nodeData[j] = zoneData.AvalibleEventNodesForZone.GetRandomNode(Random.Range(0, int.MaxValue));
                continue;
            }
            zoneLayers[i] = new layer(layerNodesDataSet.nodeData, int.MaxValue);
        }
    }

    public layer GetLayer(int layerNum)
    {
        return zoneLayers[layerNum];
    }
}
