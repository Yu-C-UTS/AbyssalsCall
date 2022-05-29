using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITemplateManager : MonoBehaviour
{
    public static UITemplateManager Instance;

    private void Awake() 
    {
        if(Instance != null)
        {
            Debug.LogWarning("Another UI Template Manager already exists, destryoing self.");
            Destroy(this);
            return;
        }    
        Instance = this;
    }

    [SerializeField]
    private WeaponSwapUIController WeaponSwapUIControllerPrefab;

    public WeaponSwapUIController CreateNewWeaponSwapUI()
    {
        WeaponSwapUIController weaponSwapUIController = Instantiate<WeaponSwapUIController>(WeaponSwapUIControllerPrefab, Vector3.zero, Quaternion.identity);
        weaponSwapUIController.InitilizeUI();
        return weaponSwapUIController;
    }
}
