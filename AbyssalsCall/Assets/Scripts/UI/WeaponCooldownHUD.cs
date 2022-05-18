using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCooldownHUD : MonoBehaviour
{
    [SerializeField]
    private Image weaponSpriteImage;

    [SerializeField]
    private Slider cooldownSlider;

    [SerializeField]
    private Gradient cooldownSliderGradient;

    [SerializeField]
    private Image cooldownSliderFill;

    public bool InverseSlider;

    public void SetWeaponSprite(Sprite WeaponSprite)
    {
        weaponSpriteImage.sprite = WeaponSprite;
    }

    public void SetSliderMaxValue(float MaxValue)
    {
        cooldownSlider.maxValue = MaxValue;
    }

    public void UpdateSliderValue(float SliderValue)
    {
        if(InverseSlider)
        {
            cooldownSlider.value = cooldownSlider.maxValue - SliderValue;
        }   
        else
        {
            cooldownSlider.value = SliderValue;
        }
        cooldownSliderFill.color = cooldownSliderGradient.Evaluate(cooldownSlider.value/cooldownSlider.maxValue);
    }
}
