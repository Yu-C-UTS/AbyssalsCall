using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    protected PathfindingController pfController;

    [SerializeField]
    protected bool hasTarget = false;
    [SerializeField]
    protected float detectRadius = 4;
    [SerializeField]
    protected float giveUpDistance = 10;

    [SerializeField]
    protected float normalSpeed = 75f;
    [SerializeField]
    protected float chaseSpeed = 150f;


    protected Transform target { get; set; }

    protected Vector3 spawnPoint;
    protected float movingRadius = 4;

    protected virtual void Awake()
    {
        pfController = new PathfindingController(transform, PickRandomPoint());
    }

    protected void Start()
    {
        spawnPoint = transform.position;
        StartCoroutine(UpdateAIPath());
    }

    protected void LateUpdate()
    {
        UpdateFacingDirection();
    }

    protected virtual void FixedUpdate()
    {
        detectPlayer("Player", detectRadius);
        UpdateSpeed();
        pfController.UpdateMovement();
    }

    protected Vector3 PickRandomPoint()
    {
        Vector3 point = Random.insideUnitCircle * movingRadius;
        point += spawnPoint;
        return point;
    }

    protected virtual void UpdateSpeed()
    {
        if (hasTarget)
        {
            pfController.speed = chaseSpeed;
        }
        else
        {
            pfController.speed = normalSpeed;
        }
        //Debug.Log(pfController.speed);
    }

    protected void UpdateFacingDirection()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (!hasTarget)
        {
            if (rb.velocity.x >= 0.01f)
            {
                GetComponentInChildren<Transform>().localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (rb.velocity.x <= -0.01f)
            {
                GetComponentInChildren<Transform>().localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else
        {
            if(directionTo(target).x >= 0.1)
            {
                GetComponentInChildren<Transform>().localScale = new Vector3(-1f, 1f, 1f);
            }else if (directionTo(target).x <= -0.1)
            {
                GetComponentInChildren<Transform>().localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    protected void detectPlayer(string targetTag, float detectR)
    {
        var hitColliders = Physics2D.OverlapCircleAll(transform.position, detectR);
        foreach (var collider in hitColliders)
        {
            if (collider.gameObject.CompareTag(targetTag))
            {
                hasTarget = true;
                target = collider.gameObject.transform.GetChild(0).transform;
                Debug.Log("detected");
            }
        }

        //TODO: raycast maybe
        if (hasTarget)
        {
            if (distanceTo(target) > giveUpDistance)
            {
                hasTarget = false;
                Debug.Log("Out of Sight");
            }
        }
    }

    protected float distanceTo(Transform target)
    {
        return Vector2.Distance(target.position, transform.position);
    }

    protected Vector2 directionTo(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        return direction.normalized;
    }

    protected IEnumerator UpdateAIPath()
    {
        while (true)
        {
            if (!hasTarget)
            {
                yield return new WaitForSeconds(3f);
                pfController.targetPos = PickRandomPoint();
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                pfController.targetPos = target.position;
            }
            pfController.UpdatePath();
        }
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, detectRadius);
    }
}
