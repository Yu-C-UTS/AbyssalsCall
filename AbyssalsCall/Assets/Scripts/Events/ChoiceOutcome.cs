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
        public virtual bool SuppressReturnToMap => false;

        public virtual void ApplyOutcome()
        {

        }
    }

    [System.Serializable]
    public class SubmarineDamage:OutcomeBase
    {
        public float DamageAmount;

        public SubmarineDamage()
        {
            OutcomeType = EOutcomeClass.submarineDamage;
        }

        public override void ApplyOutcome()
        {
            RunManager.Instance.ActivePlayerSubmarineStateData.CurrentHealth -= DamageAmount;
        }
    }

    [System.Serializable]
    public class SystemReward:OutcomeBase
    {
        public string RewardSystemName;
        public bool IsWeaponSystem = true;
        public override bool SuppressReturnToMap => true;

        public SystemReward()
        {
            OutcomeType = EOutcomeClass.systemReward;
        }

        public override void ApplyOutcome()
        {
            WeaponSwapUIController wsuo = UITemplateManager.Instance.CreateNewWeaponSwapUI();
            wsuo.SetNewWeaponOption(RewardSystemName);
        }
    }
}
