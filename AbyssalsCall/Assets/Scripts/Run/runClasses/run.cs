using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run
{
    public run()
    {
        this.runSeed = Random.Range(0, int.MaxValue).ToString();
    }

    public run(string runSeed)
    {
        this.runSeed = runSeed;
    }

    public class progress
    {
        public int ZoneNum;
        public int LayerNum;
    }

    public string runSeed;
    private map runMap;
    private List<int> nodeChoices = new List<int>();

    public void InitilizeRun(RunGenerationData runGenerationData)
    {
        runMap = new map(runGenerationData, runSeed.GetHashCode());
    }

    public void StepRun(int nodeInt)
    {
        nodeChoices.Add(nodeInt);
    }

    public node GetLatestActiveNode()
    {
        progress curPro = GetCurrentProgress();

        layer latestLayer = GetCurrentLayer();
        return latestLayer.GetNode(nodeChoices[nodeChoices.Count - 1]);
    }


    public layer GetLayer(int zoneNum, int layerNum)
    {
        return runMap.GetZone(zoneNum).GetLayer(layerNum);
    }

    public layer GetCurrentLayer()
    {
        progress curPro = GetCurrentProgress();
        return GetLayer(curPro.ZoneNum, curPro.LayerNum);
    }

    public int GetCurrentLayerNum()
    {
        return GetCurrentProgress().LayerNum;
    }


    public zone GetZone(int zoneOrder)
    {
        return runMap.GetZone(zoneOrder);
    }

    public zone GetCurrentZone()
    {
        return GetZone(GetCurrentZoneNum());
    }

    public int GetCurrentZoneNum()
    {
        return GetCurrentProgress().ZoneNum;
    }


    public progress GetCurrentProgress()
    {
        progress curProgress = new progress();

        int remainProgressNodeCount = nodeChoices.Count;

        int checkingZoneNum = 0;
        while(checkingZoneNum < runMap.ZoneCount)
        {
            if(remainProgressNodeCount < runMap.GetZone(checkingZoneNum).LayerCount)
            {
                curProgress.ZoneNum = checkingZoneNum;
                curProgress.LayerNum = remainProgressNodeCount;

                return curProgress;
            }
            remainProgressNodeCount -= runMap.GetZone(checkingZoneNum).LayerCount;
        }
        Debug.LogError("Number of chosen nodes is higher than number of avalable nodes!");
        return curProgress;
    }
}
