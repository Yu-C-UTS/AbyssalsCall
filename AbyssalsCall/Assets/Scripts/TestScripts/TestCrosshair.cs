using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestCrosshair : MonoBehaviour
{
    private void Update() 
    {
        /*
        Vector3 target = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //Place crosshair at location of mouse
        transform.position = new Vector2(target.x,target.y);    
        */
    }

    public void CursorMove(InputAction.CallbackContext MoveDelta)
    {
        transform.position += (Vector3)MoveDelta.ReadValue<Vector2>();
    }
}
