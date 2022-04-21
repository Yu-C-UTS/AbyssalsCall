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

    public string runSeed;
    private map runMap;
    private List<int> nodeChoices;

    public void InitilizeRun(RunGenerationData runGenerationData)
    {
        runMap = new map(runGenerationData, runSeed.GetHashCode());
    }

    public void StepRun(int node)
    {
        nodeChoices.Add(node);
    }

    public zone GetZone(int zoneOrder)
    {
        return runMap.GetZone(zoneOrder);
    }
}
