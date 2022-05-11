using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthHUD : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void Update()
    {
        SetSliderHealth();
    }
    private float GetCurrentHealth()
    {
        slider.value = RunManager.Instance.ActivePlayerSubmarineStateData.CurrentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        return RunManager.Instance.ActivePlayerSubmarineStateData.CurrentHealth;
    }

    private float GetMaxHealth()
    {
        slider.maxValue = RunManager.Instance.ActivePlayerSubmarineStateData.MaxHealth;
        fill.color = gradient.Evaluate(1f);
        return RunManager.Instance.ActivePlayerSubmarineStateData.MaxHealth;
    }

    private void SetSliderHealth()
    {
        GetMaxHealth();
        GetCurrentHealth();
    }
    private float GetCurrentHealthPercentage()
    {
        return GetCurrentHealth()/GetCurrentHealthPercentage();
    }
}
