using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerSubmarine : MonoBehaviour
{
    public Rigidbody2D rigidBody2d{ get; private set;}
    public Transform systemContainerTransform{ get; private set; }
    [SerializeField]
    Transform turretPivot;

    bool facingRight = true;
    const float spriteFlipSpeed = 8;

    public UnityEvent onSubUpdate;
    public UnityEvent onSubFixedUpdate;
    public UnityEvent<Vector2> onMouseMove;
    public UnityEvent<Vector2> onMove;
    public UnityEvent<float> onTriggerPrim;
    public UnityEvent<float> onTriggerSec;

    private void Awake() 
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        systemContainerTransform = new GameObject("systems").transform;
        systemContainerTransform.SetParent(transform);
    }

    private void Update() 
    {
        onSubUpdate?.Invoke();

        UpdateSubmarineFacing();
    }

    private void FixedUpdate() 
    {
        onSubFixedUpdate?.Invoke();
    }

    public void OnMoveInput(InputAction.CallbackContext value)
    {
        onMove?.Invoke(value.ReadValue<Vector2>());
    }

    public void OnTriggerPrimInput(InputAction.CallbackContext value)
    {
        onTriggerPrim?.Invoke(value.ReadValue<float>());
    }

    public void OnTriggerSecInput(InputAction.CallbackContext value)
    {
        onTriggerSec?.Invoke(value.ReadValue<float>());
    }

    public void OnCursorMoveInput(InputAction.CallbackContext value)
    {
        onMouseMove?.Invoke(value.ReadValue<Vector2>());
    }


    private void UpdateSubmarineFacing()
    {
        if(!Mathf.Approximately(rigidBody2d.velocity.x, 0))
        {
            facingRight = rigidBody2d.velocity.x > 0;
        }

        if( (facingRight && Mathf.Approximately(transform.localScale.x, 1)) || (!facingRight && Mathf.Approximately(transform.localScale.x, -1)))
        {
            return;
        }

        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x + ( facingRight ? 1 : -1 ) * Time.deltaTime * spriteFlipSpeed, -1, 1), 1, 1);
    }
}
