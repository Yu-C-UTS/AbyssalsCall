using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRunGenerationData", menuName = "ScriptableObjects/MapGenData/RunGenerationData")]
public class RunGenerationData : ScriptableObject
{
    [System.Serializable]
    private class ZoneDataList
    {
        public List<ZoneData> AvalibleZones;
    }

    [SerializeField]
    private List<ZoneDataList> AvalibleZonesForStages;

    public int GetStageCount()
    {
        return AvalibleZonesForStages.Count;
    }

    public ZoneData GetRandomZoneForStage(int stageNumber, int seed)
    {
        if(stageNumber >= AvalibleZonesForStages.Count)
        {
            return null;
        }

        if(AvalibleZonesForStages[stageNumber] == null)
        {
            return null;
        }

        Random.InitState(seed);
        ZoneDataList avalibleZoneForStage = AvalibleZonesForStages[stageNumber];
        return avalibleZoneForStage.AvalibleZones[Random.Range(0, avalibleZoneForStage.AvalibleZones.Count -1)];
    }
}
