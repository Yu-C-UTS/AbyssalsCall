using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceOutcome
{
    [System.Serializable]
    public class OutcomeBase
    {
        public enum EOutcomeClass
        { nullOutcome, submarineDamage, systemReward}

        public EOutcomeClass OutcomeType = EOutcomeClass.nullOutcome;
    }

    [System.Serializable]
    public class SubmarineDamage:OutcomeBase
    {
        public float DamageAmount;

        public SubmarineDamage()
        {
            OutcomeType = EOutcomeClass.submarineDamage;
        }
    }

    [System.Serializable]
    public class SystemReward:OutcomeBase
    {
        public string RewardSystemName;
        public bool IsWeaponSystem = false;

        public SystemReward()
        {
            OutcomeType = EOutcomeClass.systemReward;
        }
    }
}
