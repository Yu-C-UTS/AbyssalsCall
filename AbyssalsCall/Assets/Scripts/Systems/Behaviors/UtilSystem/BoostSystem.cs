using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSystem : SystemBase
{
    [SerializeField]
    protected float BoostForce = 50;
    private float buttonDownTimer = 0.3f;
    private bool boostDownTimerCheck;

    [SerializeField]
    private int boostMaxCharge = 3;
    [SerializeField]
    private float boostRechargeTimer = 3;
    private float _currentBoostCharge;
    private float currentBoostCharge
    {
        get { return _currentBoostCharge; }
        set
        {
            _currentBoostCharge = value;
            if(registeredSubmarine != null)
            {
                registeredSubmarine.BoostStatusUI.UpdateCharge(_currentBoostCharge);
            }
        }
    }

    public override List<string> GetStats()
    {
        throw new System.NotImplementedException();
    }

    public override void InitilizeSystem(PlayerSubmarine parentSubmarine)
    {
        base.InitilizeSystem(parentSubmarine);
        currentBoostCharge = boostMaxCharge;
    }

    public override void RegisterSystem()
    {
        registeredSubmarine.BoostStatusUI.gameObject.SetActive(true);
        registeredSubmarine.onBoost += BoostInput;
        registeredSubmarine.onSubUpdate += UpdateBoostRecharge;
    }

    public override void UnRegisterSystem()
    {
        registeredSubmarine.BoostStatusUI.gameObject.SetActive(false);
        registeredSubmarine.onBoost -= BoostInput;    
        registeredSubmarine.onSubUpdate -= UpdateBoostRecharge;
    }

    public void BoostInput(float triggerFloat)
    {
        if(triggerFloat > 0.5)
        {
            boostDownTimerCheck = true;
            StartCoroutine(buttonDownReset());
        }
        else
        {
            if(boostDownTimerCheck)
            {
                Boost();
            }
        }
    }

    private void Boost()
    {
        if(currentBoostCharge >= 1)
        {
            currentBoostCharge -= 1;
            Rigidbody2D submarineRb2d = registeredSubmarine.rigidBody2d;
            submarineRb2d.AddForce(submarineRb2d.velocity.normalized * BoostForce, ForceMode2D.Impulse);
        }
    }

    public void UpdateBoostRecharge()
    {
        currentBoostCharge = Mathf.Clamp(currentBoostCharge + Time.deltaTime/boostRechargeTimer, 0, boostMaxCharge);
    }

    private IEnumerator buttonDownReset()
    {
        yield return new WaitForSeconds(buttonDownTimer);
        boostDownTimerCheck = false;
    }
}
