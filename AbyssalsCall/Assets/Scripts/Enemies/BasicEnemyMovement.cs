using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    private PathfindingController pfController;

    [SerializeField]
    private bool hasTarget = false;
    private Transform target { get; set; }

    private Vector3 spawnPoint;
    private float movingRadius = 4;

    private void Awake()
    {
        if (hasTarget)
        {
            pfController = new PathfindingController(transform, target);
        }
        else
        {
            pfController = new PathfindingController(transform, PickRandomPoint());
        }
    }

    private void Start()
    {
        spawnPoint = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdateAIPath());
    }

    private void Update()
    {
        UpdateFacingDirection();
    }

    private void FixedUpdate()
    {
        UpdateSpeed();
        pfController.UpdateMovement();
    }

    Vector3 PickRandomPoint()
    {
        Vector3 point = Random.insideUnitCircle * movingRadius;
        point += spawnPoint;
        return point;
    }

    private void UpdateSpeed()
    {
        if (hasTarget)
        {
            pfController.speed = 100f;
        }else if (!hasTarget)
        {
            pfController.speed = 50f;
        }
    }

    private void UpdateFacingDirection()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.x >= 0.01f)
        {
            GetComponentInChildren<Transform>().localScale = new Vector3(1f, 1f, 1f);
        }else if(rb.velocity.x <= -0.01f)
        {
            GetComponentInChildren<Transform>().localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private IEnumerator UpdateAIPath()
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
}
