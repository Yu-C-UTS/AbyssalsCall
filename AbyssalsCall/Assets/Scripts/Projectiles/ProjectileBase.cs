using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class ProjectileBase : MonoBehaviour
{
    protected Collider2D col2d;
    public Rigidbody2D rb2d{ get; protected set;}

    [SerializeField]
    protected float projectileLifetime = 3f;

    [SerializeField]
    protected List<Payload> payloads;

    protected virtual void Awake() 
    {
        col2d = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public virtual void InitiateProjectile(GameObject projectileSource)
    {
        Destroy(gameObject, projectileLifetime);

        Collider2D sourceCollider = projectileSource.GetComponent<Collider2D>();
        if(sourceCollider != null)
        {
            Physics2D.IgnoreCollision(col2d, sourceCollider, true);
            Debug.Log("Collider Ignoring Source");
            StartCoroutine(RemoveColliderIgnore(sourceCollider, 0.5f));
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<IDamagable>(out IDamagable otherDamagable))
        {
            triggerPayload(otherDamagable, other.gameObject);
            Destroy(gameObject);
        }
    }

    protected virtual void triggerPayload(IDamagable targetDamagable, GameObject targetGameobject)
    {
        foreach(Payload payload in payloads)
        {
            payload.ActivatePayload(targetDamagable, targetGameobject);
        }
    }

    protected IEnumerator RemoveColliderIgnore(Collider2D targetCollider, float delay)
    {
        yield return new WaitForSeconds(delay);
        Physics2D.IgnoreCollision(col2d, targetCollider, false);
        Debug.Log("Collider Reset");
    }

    protected virtual void OnValidate() 
    {
        
    }
}
