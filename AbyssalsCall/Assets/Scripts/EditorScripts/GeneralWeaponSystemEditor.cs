using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GeneralWeaponSystem))]
public class GeneralWeaponSystemEditor : Editor 
{
    public override void OnInspectorGUI() 
    {
        base.OnInspectorGUI();
        
        GeneralWeaponSystem script = (GeneralWeaponSystem)target;
        string missingBehaviorWarning = "";

        if(script.GetComponent<WeaponAimBehaviorBase>() == null)
        {
            missingBehaviorWarning += "No Aim Behavior Found\n";
        }

        if(script.GetComponent<WeaponTriggerBehaviorBase>() == null)
        {
            missingBehaviorWarning += "No Trigger Behavior Found\n";
        }

        if(script.GetComponent<WeaponFireBehaviorBase>() == null)
        {
            missingBehaviorWarning += "No Fire Behavior Found\n";
        }

        if(missingBehaviorWarning.Length > 0)
        {
            EditorGUILayout.HelpBox(missingBehaviorWarning.Trim(), MessageType.Warning);
        }
    }
}