using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthHUD : MonoBehaviour
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
        slider.value = FindObjectOfType<CrabBossState>().Health;
        fill.color = gradient.Evaluate(1f);
        return slider.value;
    }

    private float GetMaxHealth()
    {
        slider.maxValue = FindObjectOfType<CrabBossState>().maxHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        return slider.maxValue;
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
