using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHUD : MonoBehaviour
{
    private float GetCurrentHealth()
    {
        return RunManager.Instance.ActivePlayerSubmarineStateData.CurrentHealth;
    }

    private float GetMaxHealth()
    {
        return RunManager.Instance.ActivePlayerSubmarineStateData.MaxHealth;
    }

    private float GetCurrentHealthPercentage()
    {
        return GetCurrentHealth()/GetCurrentHealthPercentage();
    }
}
