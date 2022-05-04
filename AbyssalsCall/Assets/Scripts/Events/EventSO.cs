using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEventData", menuName = "ScriptableObjects/Event")]
public class EventSO : ScriptableObject
{
    public string EventName = "New Event";
    [TextArea(3,7)]
    public string EveentDescription = "Description.";

    [System.Serializable]
    public class Choice
    {
        public string ChoiceText = "Choice Text";
        [SerializeReference]
        public List<ChoiceOutcome.OutcomeBase> ChoiceOutcomes;
    }

    public List<Choice> Choices;

    private void OnValidate() 
    {
        foreach(Choice choice in Choices)
        {
            for(int i = 0; i < choice.ChoiceOutcomes.Count; i++)
            {
                if(choice.ChoiceOutcomes[i] == null)
                {
                    choice.ChoiceOutcomes[i] = new ChoiceOutcome.OutcomeBase();
                }
                switch (choice.ChoiceOutcomes[i].OutcomeType)
                {
                    case ChoiceOutcome.OutcomeBase.EOutcomeClass.submarineDamage:
                    if(choice.ChoiceOutcomes[i] is not ChoiceOutcome.SubmarineDamage)
                    {
                        choice.ChoiceOutcomes[i] = new ChoiceOutcome.SubmarineDamage();
                    }
                    break;

                    case ChoiceOutcome.OutcomeBase.EOutcomeClass.systemReward:
                    if(choice.ChoiceOutcomes[i] is not ChoiceOutcome.SystemReward)
                    {
                        choice.ChoiceOutcomes[i] = new ChoiceOutcome.SystemReward();
                    }
                    break;
                    
                    case ChoiceOutcome.OutcomeBase.EOutcomeClass.nullOutcome:  
                    default:
                    if(!choice.ChoiceOutcomes[i].GetType().IsAssignableFrom(typeof(ChoiceOutcome.OutcomeBase)))
                    {
                        choice.ChoiceOutcomes[i] = new ChoiceOutcome.OutcomeBase();
                    }
                    break;
                }
            }    
        }
    }
}
