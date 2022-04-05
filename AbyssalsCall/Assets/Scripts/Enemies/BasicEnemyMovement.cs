using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BasicEnemyMovement : MonoBehaviour
{
    private Seeker seeker;
    private Rigidbody2D rb;
    private PathfindingController pfController;

    [SerializeField]
    private bool hasTarget = false;
    [SerializeField]
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

    private void FixedUpdate()
    {
        pfController.UpdateMovement();
    }

    Vector3 PickRandomPoint()
    {
        Vector3 point = Random.insideUnitCircle * movingRadius;
        point += spawnPoint;
        return point;
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
