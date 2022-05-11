using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSwapUIController : MonoBehaviour
{
    private string NewWeaponKeyString;

    [SerializeField]
    private TMP_Text NewWeaponNameText;
    [SerializeField]
    private TMP_Text NewWeaponDescriptionText;

    [SerializeField]
    private TMP_Text PrimWeaponNameText;

    [SerializeField]
    private TMP_Text SecWeaponNameText;

    public void InitilizeUI()
    {
        SystemBase PrimWeapon = StringSystemConverter.Instance.StringToSystem(RunManager.Instance.ActivePlayerSubmarineStateData.PrimWeapon);
        PrimWeaponNameText.text = PrimWeapon.SystemName;
    
        if(RunManager.Instance.ActivePlayerSubmarineStateData.SecWeapon == "")
        {
            SecWeaponNameText.text = "Nothing Installed";
        }
        else
        {
            SystemBase SecWeapon = StringSystemConverter.Instance.StringToSystem(RunManager.Instance.ActivePlayerSubmarineStateData.SecWeapon);
            if(SecWeapon != null)
            {
                SecWeaponNameText.text = SecWeapon.SystemName;
            }
        }
    }

    public void SetNewWeaponOption(string WeaponKeyString)
    {
        NewWeaponKeyString = WeaponKeyString;

        SystemBase NewWeapon = StringSystemConverter.Instance.StringToSystem(NewWeaponKeyString);
        if(NewWeapon == null)
        {
            Debug.LogError("Unknown System Passed to Weapon Swap Canvas.");
            return;
        }
        NewWeaponNameText.text = NewWeapon.SystemName;
        NewWeaponDescriptionText.text = NewWeapon.SystemDescriptionText;
    }

    public void AssignWeaponToPrim()
    {
        RunManager.Instance.ActivePlayerSubmarineStateData.ReplacePrimWeapon(NewWeaponKeyString);

        ReturnToMap();
    }

    public void AssignWeaponToSec()
    {
        RunManager.Instance.ActivePlayerSubmarineStateData.ReplaceSecWeapon(NewWeaponKeyString);
    
        ReturnToMap();
    }

    public void ReturnToMap()
    {
        GameObject.FindObjectOfType<SceneController>().ReturnToMapDisplay();
    }
}
