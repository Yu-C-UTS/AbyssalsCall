using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerSubmarine : MonoBehaviour, IDamagable
{
    public delegate void UpdateNotify();
    public delegate void VectorChange(Vector2 V2Value);
    public delegate void TriggerChange(float TriggerValue);

    public Rigidbody2D rigidBody2d{ get; private set;}
    public Transform systemContainerTransform{ get; private set; }
    [field: SerializeField]
    public Transform turretPivotAnchor{ get; private set;}
    [field: SerializeField]
    public Transform topMountAnchor{ get; private set;}    
    [field: SerializeField]
    public Transform bottomMountAnchor{ get; private set;}    
    [field: SerializeField]
    public Transform frontMountAnchor{ get; private set;}    
    [field: SerializeField]
    public Transform rearMountAnchor{ get; private set;}

    [field: SerializeField]
    public Transform submarineVisualTransform{ get; private set;}

    [field: SerializeField]
    public Transform WeaponHudParent{ get; private set;}
    [field: SerializeField]
    public BoostStatusUI BoostStatusUI{ get; private set; }

    bool facingRight = true;

    public event UpdateNotify onSubUpdate;
    public event UpdateNotify onSubFixedUpdate;
    public event VectorChange onMouseMove;
    public event VectorChange onMove;
    public event TriggerChange onBoost;
    public event TriggerChange onTriggerPrim;
    public event TriggerChange onTriggerSec;

    private void Awake() 
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        systemContainerTransform = new GameObject("systems").transform;
        systemContainerTransform.SetParent(transform);

        if(turretPivotAnchor == null)
        {
            Debug.LogError("ERROR: Turret pivot not assigned for submarine.");
        }
    }

    private void Start() 
    {
        StartCoroutine(ActivateUserInputCoroutine());
    }

    private IEnumerator ActivateUserInputCoroutine()
    {
        for(int waitFrame = 0; waitFrame < 3; waitFrame++)
        {
            yield return null; 
        }
        GetComponent<PlayerInput>().enabled = true;
        GetComponent<PlayerInput>().ActivateInput();    
        yield break;
    }

    private void Update() 
    {
        onSubUpdate?.Invoke();
        //UpdateSubmarineFacing();
    }

    private void FixedUpdate() 
    {
        onSubFixedUpdate?.Invoke();
    }

    public void OnMoveInput(InputAction.CallbackContext value)
    {
        onMove?.Invoke(value.ReadValue<Vector2>());

        UpdateSubmarineFacing(value.ReadValue<Vector2>().x);
    }

    public void OnBoostInput(InputAction.CallbackContext value)
    {
        onBoost?.Invoke(value.ReadValue<float>());
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

    /*
    const float spriteFlipSpeed = 8;

    [System.Obsolete("Flip turn animation, this one uses current velocity to determine direction.")]
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
    */

    public Transform GetWeaponAnchorPoint(WeaponObject.AnchorPoint anchorPoint)
    {
        switch (anchorPoint)
        {
            case WeaponObject.AnchorPoint.turret:
            return turretPivotAnchor;

            case WeaponObject.AnchorPoint.bottom:
            return bottomMountAnchor;
            
            case WeaponObject.AnchorPoint.top:
            return topMountAnchor;

            case WeaponObject.AnchorPoint.front:
            return frontMountAnchor;
            
            case WeaponObject.AnchorPoint.back:
            return rearMountAnchor;

            default:
            Debug.LogWarning("Unknown Anchor Point Type, returning bottom mount.");
            return bottomMountAnchor;
        }
    }

    private void UpdateSubmarineFacing(float XMovementSpeed)
    {
        if(!Mathf.Approximately(XMovementSpeed, 0))
        {
            facingRight = XMovementSpeed > 0;
        }

        submarineVisualTransform.localScale = new Vector3((facingRight ? 1 : -1), 1, 1);
    }

    public void TakeDamage(Damage damage)
    {
        RunManager.Instance.ActivePlayerSubmarineStateData.CurrentHealth -= damage.baseDamageValue;
    }
}
