using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrabBossHealthHUD : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void Update()
    {
        SetSliderHealth();
        CheckForHealth();
    }
    private float GetCurrentHealth()
    {
        slider.value = FindObjectOfType<CrabBossState>().Health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        return slider.value;
    }

    private float GetMaxHealth()
    {
        slider.maxValue = FindObjectOfType<CrabBossState>().maxHealth;
        fill.color = gradient.Evaluate(1f);
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
    
    private void CheckForHealth() //Temp
    {
        if (slider.value == 0)
        {
            GameSceneManager.Instance.LoadScene("MapDisplayScene");
        }
    }
}
