using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map
{
    public map(RunGenerationData runGenerationData, int seed)
    {
        this.seed = seed;
        InitilizeMap(runGenerationData);
    }

    public int seed{ get; private set;}

    private zone[] runZones;

    public void InitilizeMap(RunGenerationData runGenerationData)
    {
        System.Random runRandomizer = new System.Random(seed);

        int generateZoneCount = runGenerationData.GetStageCount();

        runZones = new zone[generateZoneCount];
        for (int i = 0; i < generateZoneCount; i++)
        {
            runZones[i] = new zone(runGenerationData.GetRandomZoneForStage(i, runRandomizer.Next()));
            runZones[i].InitilizeZone(runRandomizer.Next());
        }

    }

    public zone GetZone(int zoneOrder)
    {
        return runZones[zoneOrder];
    }
}
