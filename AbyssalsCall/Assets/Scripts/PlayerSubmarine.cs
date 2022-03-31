using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerSubmarine : MonoBehaviour
{
    Rigidbody2D rb2;

    [SerializeField]
    float baseSpeed = 5f;

    private Vector2 moveDirection;

    private void Awake() 
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        rb2.AddForce(moveDirection * baseSpeed);    
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>();
    }
}
