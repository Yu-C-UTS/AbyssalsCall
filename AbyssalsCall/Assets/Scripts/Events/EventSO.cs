using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEventData", menuName = "ScriptableObjects/Event")]
public class EventSO : ScriptableObject
{
    public string EventName = "New Event";
    [TextArea(3,7)]
    public string EveentDescription = "Description.";
}
