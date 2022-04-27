using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEventData", menuName = "ScriptableObjects/Event")]
public class EventSO : ScriptableObject
{
    [System.Serializable]
    public class OutcomeBase
    {
        public enum EOutcomeClass
        { nullOutcome}

        public EOutcomeClass OutcomeClass = EOutcomeClass.nullOutcome;
        public string ButtonText = "Choice button";
    }

    [System.Serializable]
    public class SystemReward:OutcomeBase
    {

    }

    public string EventName = "New Event";
    [TextArea(3,7)]
    public string EveentDescription = "Description.";

    public List<OutcomeBase> OutcomeChoices;
}
