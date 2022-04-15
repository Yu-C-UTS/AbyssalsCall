using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraPositioner : MonoBehaviour
{
    public Transform focusTransform1;
    public Transform focusTransform2;

    void LateUpdate()
    {
        if(focusTransform1 != null && focusTransform2 != null)
        {
            Vector3 newCameraPosition = new Vector3(
                (focusTransform1.position.x + focusTransform2.position.x) / 2,
                (focusTransform1.position.y + focusTransform2.position.y) / 2,
                Camera.main.transform.position.z);
            Camera.main.transform.SetPositionAndRotation(newCameraPosition, Quaternion.identity);
        }
    }
}
