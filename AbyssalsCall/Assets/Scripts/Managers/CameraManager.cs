using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public enum CameraMode
    { inactive, focusSingle, focusBetween}

    public static CameraManager Instance;

    public CameraMode CurrentCameraMode;

    public Transform MainFocusTransform;
    public Transform SecondaryFocusTransform;

    protected void Awake() 
    {
        if(Instance != null)
        {
            Debug.LogWarning("Found another active camera manager instance, destroying the other active manager.");
            Destroy(Instance);
        }    
        Instance = this;
    }

    protected void LateUpdate() 
    {
        switch (CurrentCameraMode)
        {
            case CameraMode.inactive:
            return;

            case CameraMode.focusSingle:
            focusSingleCameraUpdate();
            break;

            case CameraMode.focusBetween:
            focusBetweenCameraUpdate();
            break;
            
            default:
            Debug.LogError("Unknown Camera Operation Mode Detected, falling back to single focus mode.");
            CurrentCameraMode = CameraMode.focusSingle;
            focusSingleCameraUpdate();
            break;
        }
    }

    protected void focusSingleCameraUpdate()
    {
        if(MainFocusTransform == null)
        {
            Debug.LogWarning("No Focus transform assigned, leaving camera untouched.");
            return;
        }

        Vector3 newCameraPosition = new Vector3( MainFocusTransform.position.x, MainFocusTransform.position.y, Camera.main.transform.position.z);
        Camera.main.transform.SetPositionAndRotation(newCameraPosition, Quaternion.identity);
    }

    protected void focusBetweenCameraUpdate()
    {
        if(SecondaryFocusTransform == null)
        {
            Debug.LogWarning("Secondary Focus for camera is not set, falling back to single focus.");
        }

        Vector3 newCameraPosition = new Vector3(
            (MainFocusTransform.position.x + SecondaryFocusTransform.position.x) / 2,
            (MainFocusTransform.position.y + SecondaryFocusTransform.position.y) / 2,
            Camera.main.transform.position.z);
        Camera.main.transform.SetPositionAndRotation(newCameraPosition, Quaternion.identity);
    }

}
